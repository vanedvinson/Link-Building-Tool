using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.ObjectModel;
using SystemDuo.Components.Dialogs;
using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Dto;
using SystemDuo.Core.Services.Abstractions;
using SystemDuo.ViewModels.Interfaces;

namespace SystemDuo.ViewModels
{
    public class JobsViewModel : BaseViewModel
    {

        private ObservableCollection<Job> _jobs = new();
        private Job _selectedJob = new();
        private Application NewCandidateApplication = new();

        public string? _searchStringJobs;
        public string? _searchStringArchJobs;
        private ObservableCollection<Category> _categories = new();
        private Category? _category = new();
        protected override async Task OnInitializedAsync()
        {

            PropertyChanged += async (sender, e) =>
            {
                await InvokeAsync(() =>
                {
                    StateHasChanged();
                });

            };
           await GetAllJobs();

           await GetAllCategories();
        }
     
        public void NavigateToNewJob()
        {
            NavigationManager!.NavigateTo("/create/job");

        }
        public void NavigateToUpdateJob(Guid JobId)
        {
            NavigationManager!.NavigateTo("/update/job/"+JobId,false);
        }
        public async Task GetAllCategories()
        {
            var categories = await ServiceManager!.JobCategoryService.GetAllCategoriesAsync();
            if (categories != null)
            {
                Categories = new ObservableCollection<Category>(categories);
            }
        }
        public async Task SendJobApplication(Guid jobId)
        {
            NewCandidateApplication.UserId = "2541308a-1ec4-45dc-a3ab-76791937b636";
            NewCandidateApplication.JobId = jobId;
            await ServiceManager!.ApplicationService.SendJobApplicationAsync(NewCandidateApplication);
          
        }
        public async Task DeleteJob(Guid jobId)
        {
            var parameters = new DialogParameters();
            parameters.Add("ContentText", "Do you really want to deactivate job add.");
            parameters.Add("ButtonText", "Deactivate");
            parameters.Add("Color", Color.Error);

            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };

            var dialog = DialogService!.Show<ConfirmComponent>("Deactivate", parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
              //  var res = await DeleteJobs(jobId);
                await ServiceManager!.JobService.DeleteJob(jobId);
              //  if (res)
               // {
                    Snackbar!.Add($"Success deativated job", Severity.Success);
                    await GetAllJobs();
               // }
            }

        }
        public async Task UndoDeleteJob(Guid jobId)
        {
            var parameters = new DialogParameters();
            parameters.Add("ContentText", "Do you really want to activate job add.");
            parameters.Add("ButtonText", "Activate");
            parameters.Add("Color", Color.Error);

            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };

            var dialog = DialogService!.Show<ConfirmComponent>("Activate", parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                await ServiceManager!.JobService.UndoDeleteJob(jobId);
               // if (res)
                //{
                    Snackbar!.Add($"Success activated job", Severity.Success);
                    await GetAllInactiveJobs();
                //}
            }

        }

        public async Task GetAllJobs()
        {
            var jobs = await ServiceManager!.JobService.GetAllJobsAsync();
            if (jobs != null)
            {
                _jobs = new ObservableCollection<Job>(jobs);
                StateHasChanged();
            }
            

           

        }
        public async Task GetJobsByCategory(Category cat)
        {
            var jobs = await ServiceManager!.JobService.GetJobsByCategoryAsync(cat);
            if (jobs != null)
            {
                Jobs = new ObservableCollection<Job>(jobs);
            }
        }
        public async void FilterJobsByCategory()
        {
            if (_category!.Name != "Show All")
                await GetJobsByCategory(Category);
            else
                await GetAllJobs();

        }
        public async Task GetAllInactiveJobs()
        {
            var jobs = await ServiceManager!.JobService.GetAllInactiveJobsAsync();
            if (jobs != null)
                _jobs = new ObservableCollection<Job>(jobs);

        }
        public async Task AcceptApplication(Application application)
        {
            var parameters = new DialogParameters();
            parameters.Add("ContentText", "Do you want to accept this application?");
            parameters.Add("ButtonText", "Accept");
            parameters.Add("Color", Color.Success);

            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };

            var dialog = DialogService!.Show<ConfirmComponent>("Confirm", parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var res = await ServiceManager!.JobService.AcceptApplication(application);
                if (res)
                {
                    Snackbar!.Add($"Application accepted", Severity.Success);
                    await GetAllJobs();
                }
            }
        }
        public async Task RejectApplication(Application application)
        {
            var parameters = new DialogParameters();
          
            parameters.Add("ButtonText", "Reject");
            parameters.Add("Color", Color.Success);

            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.Medium };

            var dialog = DialogService!.Show<RejectApplicationComponent>("Reject", parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var rejectReason = result.Data as string;
                application.RejectReason = rejectReason;
                var res = await ServiceManager!.JobService.RejectApplication(application);
                if (res)
                {
                    Snackbar!.Add($"Application rejected", Severity.Success);
                    await GetAllJobs();
                }
            }
        }
        public async Task HireApplicant(Application application)
        {
            var parameters = new DialogParameters();
            parameters.Add("ContentText", "Do you really want to hire this candidate?");
            parameters.Add("ButtonText", "Accept");
            parameters.Add("Color", Color.Success);

            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };

            var dialog = DialogService!.Show<ConfirmComponent>("Hire", parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                
                var res = await ServiceManager!.JobService.HireApplicant(application);
                if (res)
                {
                    
                    Snackbar!.Add($"Candidate hired", Severity.Success);
                    await GetAllJobs();
                }
            }
        }
        public async Task UndoRejectionApplication(Application application)
        {
            var parameters = new DialogParameters();
            parameters.Add("ContentText", "Do you really want to undo this rejection?");
            parameters.Add("ButtonText", "Undo");
            parameters.Add("Color", Color.Success);

            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };

            var dialog = DialogService!.Show<ConfirmComponent>("Undo", parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {

                var res = await ServiceManager!.JobService.UndoRejectionApplication(application);
                if (res)
                {

                    Snackbar!.Add($"Rejection undo", Severity.Success);
                    await GetAllJobs();
                }
            }
        }
        
        public async Task OpenAddCandidateDialog(Job SelectedJob)
        {
            var parameters = new DialogParameters();
            parameters.Add("SelectedJob", SelectedJob);

            parameters.Add("Color", Color.Success);

            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraLarge };

            var dialog = DialogService!.Show<AddCandidateToJobApplicationComponent>("Add", parameters, options);

            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                foreach(var item in result!.Data! as HashSet<User>)
                {
                    NewCandidateApplication.UserId = item.Id;

                    NewCandidateApplication.JobId = SelectedJob.Id;
                    var res = await ServiceManager!.ApplicationService.SendJobApplicationAsync(NewCandidateApplication);
                    if (res)
                    {
                        Snackbar!.Add($"Application submitted", Severity.Success);
                        NewCandidateApplication = new();
                        await GetAllJobs();
                    }
                }
                
            }
        }
        public async Task OpenAddApplicationCommentDialog(Application application)
        {
            var parameters = new DialogParameters();
           
            parameters.Add("Color", Color.Success);
            parameters.Add("ButtonText","Save");
            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.Medium };

            var dialog = DialogService!.Show<AddApplicationCommentComponent>("Comment", parameters, options);

            var result = await dialog.Result;
            if (!result.Cancelled)
            {
               var comment=result.Data as string;
                   
                    var res = await ServiceManager!.ApplicationService.CreateApplicationCommentAsync(new ApplicationComments
                    {
                        Application=application,
                        User=application.User,
                        Comment= comment
                     
                    });
                    if (res)
                    {
                        Snackbar!.Add($"Status changed", Severity.Success);
                        NewCandidateApplication = new();
                        //await GetAllJobs();
                    }
                
            }

        }
        public async Task OpenApplyForJobDialog(Job SelectedJob)
        {
            var parameters = new DialogParameters();
            parameters.Add("SelectedJob", SelectedJob);
        
            parameters.Add("Color", Color.Success);

            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraLarge };

            var dialog = DialogService!.Show<ApplyForJobComponent>("Apply", parameters, options);
            
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                NewCandidateApplication.UserId = "2541308a-1ec4-45dc-a3ab-76791937b636";
                NewCandidateApplication.JobId = SelectedJob.Id;
                var res = await ServiceManager!.ApplicationService.SendJobApplicationAsync(NewCandidateApplication);
                if (res)
                {
                    Snackbar!.Add($"Application submitted", Severity.Success);
                    //await GetAllJobs();
                }
            }
        }
        //TODO vidi sa mersom
        public async Task GetHiredApplicant(Guid jobId)
        {
            Job tmpJob = Jobs.First(f => f.Id == jobId);
            tmpJob.CandidateApplications = await GetCandidateApplications(jobId);
        }
        public async Task ShowDetails(Guid jobId)
        {
            Job tmpJob = Jobs.First(f => f.Id == jobId);
            tmpJob.CandidateApplications = await GetCandidateApplications(jobId);
            tmpJob.ShowDetails = !tmpJob.ShowDetails;
        }
        public async Task<ICollection<Application>> GetCandidateApplications(Guid jobId)
        {
            var res = await ServiceManager!.ApplicationService.GetApplicationsByJobId(jobId);
            return (ICollection<Application>)res;

        }


        //For the Table Search
        public bool FilterFunc1(Job element) => FilterFunc(element, SearchStringJobs);
        public bool FilterFunc2(Job element) => FilterFunc(element, SearchStringArchJobs);
        private bool FilterFunc(Job element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;

            if (element.Name!.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (element.Company!.Name!.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (element.Company!.Category!.Name!.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (!string.IsNullOrEmpty(element.EducationLevel))
            {
                if (element.EducationLevel!.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
           

            return false;
        }


        public ObservableCollection<Job> Jobs
        {
            get { return _jobs; }
            set { SetValue(ref _jobs, value); }
        }
        public Job SelectedJob
        {
            get { return _selectedJob; }
            set { SetValue(ref _selectedJob, value); }
        }
        public String SearchStringJobs
        {
            get { return _searchStringJobs!; }
            set { SetValue(ref _searchStringJobs, value); }
        }
        public String SearchStringArchJobs
        {
            get { return _searchStringArchJobs!; }
            set { SetValue(ref _searchStringArchJobs, value); }
        }
        public ObservableCollection<Category> Categories
        {
            get { return _categories; }
            set { SetValue(ref _categories, value); }
        }

        public Category Category
        {
            get { return _category!; }
            set
            {
                SetValue(ref _category, value);
                FilterJobsByCategory();
            }
        }
    }


    
}
