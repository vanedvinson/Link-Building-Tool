using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;
using SystemDuo.Components.JobLocationComponent;
using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.ViewModels
{
    public class CompanyCreateUpdateViewModel:BaseViewModel
    {
        private Company _company = new();
        private ObservableCollection<Category> _jobsCategories = new();
        private Category _selectedJobsCategory = new();
        private ObservableCollection<Location> _locations = new();

        //parameter is set when update is selected
        [Parameter] public Guid companyId { get; set; }
        protected override async Task OnInitializedAsync()
        {

            PropertyChanged += async (sender, e) =>
            {
                await InvokeAsync(() =>
                {
                    StateHasChanged();
                });

            };
            await GetAllJobsCategories();

            await GetAllLocations();
            if (companyId != Guid.Empty)
            {
                await GetCompanyByIdAsync(companyId);
            }
          

        }
        public async Task OpenCreateLocation()
        {

            var dialog = DialogService!.Show<JobLocationFormComponent>("Create location");

            var res = await dialog.Result;
            if (!res.Cancelled)
            {
                await GetAllLocations();

                dialog.Close();
            }


        }
        public async Task GetCompanyByIdAsync(Guid companyId) {
            var res = await ServiceManager!.CompanyService.GetCompanyByIdAsync(companyId);
            if (res != null)
            {
                _company = res;
                _selectedJobsCategory = _company.Category!;
                StateHasChanged();
            }
               
        }
        public async Task GetAllLocations()
        {
            var locations = await ServiceManager!.JobService.GetAllJobLocationsAsync();
            if (_locations != null)
                _locations = new ObservableCollection<Location>(locations);
        }
        public string state = "Message box hasn't been opened yet";
        public async Task CreateOrUpdateCompany()
        {
            if (SelectedJobCategory.Id==Guid.Empty)
            {
                bool? result = await DialogService!.ShowMessageBox(
                  "Warning",
                  "Select Category!",
                  yesText: "Ok!", cancelText: "Cancel");
                state = result == null ? "Cancelled" : "Ok!";
                StateHasChanged();
                return;
            }
            if (Company.Location==null)
            {
                bool? result = await DialogService!.ShowMessageBox(
                  "Warning",
                  "Select Location!",
                  yesText: "Ok!", cancelText: "Cancel");
                state = result == null ? "Cancelled" : "Ok!";
                StateHasChanged();
                return;
            }
            if (Company.Id != Guid.Empty)
            {
                Company.CategoryId = SelectedJobCategory.Id;
                var res = await ServiceManager!.CompanyService.UpdateCompany(Company);
                if (res)
                {
                    //TODO Add snackbar for success update
                    
                    Company = new();
                    NavigationManager!.NavigateTo("/companies", false);
                }
                
            }
            else
            {
                Company.CategoryId=SelectedJobCategory.Id;
                var res = await ServiceManager!.CompanyService.CreateCompany(Company);
                if (res)
                {
                    //TODO Add snackbar for success create
                    Company = new();
                    NavigationManager!.NavigateTo("/companies", false);
                }
            }
            
           


            // return res;
        }
        public async Task GetAllJobsCategories()
        {
            var jobsCategories = await ServiceManager!.JobCategoryService.GetAllCategoriesAsync();
            if (jobsCategories != null)
                _jobsCategories = new ObservableCollection<Category>(jobsCategories);
        }
        public Company Company
        {
            get { return _company; }
            set { SetValue(ref _company, value); }
        }
        public Category SelectedJobCategory
        {
            get { return _selectedJobsCategory; }
            set { SetValue(ref _selectedJobsCategory, value); }
        }
        public ObservableCollection<Category> JobsCategories
        {
            get { return _jobsCategories; }
            set { SetValue(ref _jobsCategories, value); }
        }
        public ObservableCollection<Location> Locations
        {
            get { return _locations; }
            set { SetValue(ref _locations, value); }
        }
    }
}
