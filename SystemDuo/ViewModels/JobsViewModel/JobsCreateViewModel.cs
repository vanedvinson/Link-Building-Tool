
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.ObjectModel;
using SystemDuo.Components.Dialogs;
using SystemDuo.Components.JobLocationComponent;
using SystemDuo.Core.Domain.Entities;
using SystemDuo.ViewModels;
using SystemDuo.Core.Dto;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace SystemDuo.ViewModels
{
    public class JobsCreateViewModel:BaseViewModel
    {    
        private ObservableCollection<Company> _companies = new();
        private ObservableCollection<Skills> _skills = new();
        private ObservableCollection<Category> _jobsCategories = new();
        private ObservableCollection<User> _agents = new();
        private ObservableCollection<Location> _jobLocations = new();
        private IEnumerable<Skills> _selectedSkills = new HashSet<Skills>();
        private Company _selectedCompany=new();
        private Category _selectedJobsCategory = new();
        private Location _selectedJobLocation = new();

        [Required]
        private User _selectedAgent;
        private JobForCreationDto _newJob = new();
        private IEnumerable<string> _selectedLanguages=new List<string>();
        

        [Parameter] public Guid jobId { get; set; }

        protected override async Task OnInitializedAsync()
        {

            PropertyChanged += async (sender, e) =>
            {
                await InvokeAsync(() =>
                {
                    StateHasChanged();
                });
                
            };
            await base.OnInitializedAsync();
            await GetAllCompanies();
            await GetAllAgents();
            await GetAllSkills();
            await GetAllJobsCategories();
           // await GetAllJobLocations();
            if (jobId != Guid.Empty)
            {
                await GetAllJobsByIdAsync(jobId);
            }


        }
        public string state = "Message box hasn't been opened yet";
        public async Task CreateJobOrUpdate()
        {
            //TODO Refactor


            if (SelectedAgent==null)
            {
                bool? result = await DialogService!.ShowMessageBox(
                   "Warning",
                   "Select Agent !",
                   yesText: "Ok!", cancelText: "Cancel");
                state = result == null ? "Cancelled" : "Ok!";
                StateHasChanged();
                return;

            }
            if (SelectedCompany.Id == Guid.Empty)
            {
                bool? result = await DialogService!.ShowMessageBox(
                   "Warning",
                   "Select Company !",
                   yesText: "Ok!", cancelText: "Cancel");
                state = result == null ? "Cancelled" : "Ok!";
                StateHasChanged();
                return;

            }
            if (SelectedSkills.Count() == 0)
            {
                bool? result = await DialogService!.ShowMessageBox(
                  "Warning",
                  "Select Skills!",
                  yesText: "Ok!", cancelText: "Cancel");
                state = result == null ? "Cancelled" : "Ok!";
                StateHasChanged();
                return;
            }
            NewJob.CompanyId = SelectedCompany.Id;
            NewJob.AssignedToId = SelectedAgent.Id;
            NewJob.Skills = SelectedSkills;
            NewJob.LocationId = null;
            

           // NewJob.Id = Guid.NewGuid();
          //  NewJob.JobsCategoryId = SelectedJobCategory.Id;
            if (NewJob.Id != Guid.Empty)
            {
                SetLanguge();
                var res = await ServiceManager!.JobService.UpdateJob(NewJob);
                if (res)
                {
                    SelectedCompany = new();
                    SelectedSkills = new HashSet<Skills>();
                    SelectedJobCategory = new();
                    //SelectedJobLocation = new();
                    SelectedLanguages = new List<string>();
                    NewJob = new();

                }
                NavigationManager!.NavigateTo("/jobs", false);
            }
            else
            {
                SetLanguge();
                var res = await ServiceManager!.JobService.CreateJob(NewJob);
                if (res)
                {
                    SelectedCompany = new();
                    SelectedSkills = new HashSet<Skills>();
                    SelectedJobCategory = new();

                   // SelectedJobLocation = new();
                    SelectedLanguages = new List<string>();
                    NewJob = new();
                    NavigationManager!.NavigateTo("/jobs", false);
                }
            }
            
         
        }
        public void SetLanguge()
        {
            if (SelectedLanguages.Count() == 1)
            {
                NewJob.Language = SelectedLanguages.First().ToString();
            }
            else
            {
                foreach (var lang in SelectedLanguages)
                {
                    NewJob.Language = lang + "," + NewJob.Language;
                }

            }
        }
        public async Task OpenCreateJobLocation()
        {
            
            var dialog = DialogService!.Show<JobLocationFormComponent>("Create Job location");
            
            var res = await dialog.Result;
            if (!res.Cancelled)
            {
                await GetAllJobLocations();

                dialog.Close();
            }


        }

        public async Task GetAllJobsByIdAsync(Guid jobId)
        {
             var res = await ServiceManager!.JobService.GetJobByIdAsync(jobId);
            if (res != null)
            {
                _newJob.Id = res.Id;
                _newJob.Name = res.Name;
                _newJob.Description = res.Description;
                _newJob.ShortDescription = res.ShortDescription;
                _newJob.StartDate = res.StartDate;
                _newJob.EndDate = res.EndDate;
                _newJob.Type = res.Type;
                _newJob.Notes = res.Notes;
                SelectedAgent = res.AssignedTo!;
                SelectedCompany = res.Company!;
                SelectedCompany.Category = res.Company.Category;
                // SelectedJobLocation = res.Location!;
                _newJob.JobLocation = res.JobLocation;
                _newJob.Language=res.Language;
                _newJob.EducationLevel=res.EducationLevel;
             
                var list=new List<Skills>();
                foreach (var i in res.JobSkills!)
                {
                    var find = Skills.Where(x => x.Id == i.SkillId).FirstOrDefault();
                    list.Add(find);
                }
                SelectedSkills = new List<Skills>(list);


                try
                {
                    if (_newJob.Language != null)
                    {
                        string[] languages = _newJob.Language!.Split(',');
                        var listLang = new List<string>();

                        foreach (string language in languages)
                        {
                            if (language != String.Empty)
                            {
                                listLang.Add(language);
                            }


                            // SelectedLanguages.Add()
                        }
                        SelectedLanguages = new List<string>(listLang);
                    }

                }
                catch (Exception ex)
                {

                }
                StateHasChanged();

            }
        }
        public async Task GetAllCompanies()
        {
            var companies = await ServiceManager!.CompanyService.GetAllCompaniesAsync();
            if (companies != null)
                _companies = new ObservableCollection<Company>(companies);
        }
        public async Task GetAllAgents()
        {
            var agents = await ServiceManager!.UserService.GetByRoleAsync("Senior Agent");
            if (agents != null)
                _agents = new ObservableCollection<User>(agents);
        }
        public async Task GetAllSkills()
        {
            var skills = await ServiceManager!.SkillService.GetAllSkillsAsync();
            if (skills != null)
                _skills = new ObservableCollection<Skills>(skills);
        }

        public async Task GetAllJobLocations()
        {
            var jobLocations = await ServiceManager!.JobService.GetAllJobLocationsAsync();
            if (jobLocations != null)
                _jobLocations = new ObservableCollection<Location>(jobLocations);
        }
        //TODO DELETe
        public async Task GetAllJobsCategories()
        {
            var jobsCategories = await ServiceManager!.JobCategoryService.GetAllCategoriesAsync();
            if (jobsCategories != null)
                _jobsCategories = new ObservableCollection<Category>(jobsCategories);
        }
        public ObservableCollection<Company> Companies
        {
            get { return _companies; }
            set { SetValue(ref _companies, value); }
        }
        public Company SelectedCompany
        {
            get { return _selectedCompany; }
            set { SetValue(ref _selectedCompany, value); }
        }
        public User SelectedAgent
        {
            get { return _selectedAgent; }
            set { SetValue(ref _selectedAgent, value); }
        }
        public Category SelectedJobCategory
        {
            get { return _selectedJobsCategory; }
            set { SetValue(ref _selectedJobsCategory, value); }
        }
        public Location SelectedJobLocation
        {
            get { return _selectedJobLocation; }
            set { SetValue(ref _selectedJobLocation, value); }
        }
        public JobForCreationDto NewJob
        {
            get { return _newJob; }
            set { SetValue(ref _newJob, value); }
        }
        public ObservableCollection<Skills> Skills
        {
            get { return _skills; }
            set { SetValue(ref _skills, value); }
        }
        public ObservableCollection<Category> JobsCategories
        {
            get { return _jobsCategories; }
            set { SetValue(ref _jobsCategories, value); }
        }
        public ObservableCollection<User> Agents
        {
            get { return _agents; }
            set { SetValue(ref _agents, value); }
        }
        public ObservableCollection<Location> JobLocations
        {
            get { return _jobLocations; }
            set { SetValue(ref _jobLocations, value); }
        }
        public IEnumerable<Skills> SelectedSkills
        {
            get { return _selectedSkills; }
            set { SetValue(ref _selectedSkills, value); }
        }
        public IEnumerable<string> SelectedLanguages
        {
            get { return _selectedLanguages; }
            set { SetValue(ref _selectedLanguages, value); }
        }
    }
}
