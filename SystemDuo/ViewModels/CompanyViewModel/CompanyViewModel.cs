using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.ObjectModel;
using SystemDuo.Components.Dialogs;
using SystemDuo.Core.Domain;
using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Services.Abstractions;
using SystemDuo.Helpers;

namespace SystemDuo.ViewModels
{
    public class CompanyViewModel:BaseViewModel
    {
        private ObservableCollection<Company> _companies = new();

        public string? _searchStringCompanies;
        public string? _searchStringArchCompanies;
        public string? _searchStringCompanyJobs;
        public string? _searchStringArchCompanyJobs;


        protected override async Task OnInitializedAsync()
        {

            PropertyChanged += async (sender, e) =>
            {
                await InvokeAsync(() =>
                {
                    StateHasChanged();
                });

            };
            
            await GetAllCompanies();
           

        }
        public async Task GetAllCompanies()
        {
            var companies = await ServiceManager!.CompanyService.GetAllCompaniesAsync();
            if (companies != null)
                _companies = new ObservableCollection<Company>(companies);
        }
        public async Task GetAllDeletedCompanies()
        {
            var companies = await ServiceManager!.CompanyService.GetAllDeletedCompaniesAsync();
            if (companies != null)
                _companies = new ObservableCollection<Company>(companies);
        }
        public async Task DeleteCompany(Guid companyId)
        {
            var dialogResult = await SetConfirmDialog();
            if (!dialogResult.Cancelled)
            {
                var isSuccess = await ServiceManager!.CompanyService.DeleteCompany(companyId);
                if (isSuccess)
                {
                    await GetAllCompanies();
                }
            }          
        }
        public async Task UndoDeletedCompany(Guid companyId)
        {
            var dialogResult = await SetUndoConfirmDialog();
            if (!dialogResult.Cancelled)
            {
                var isSuccess = await ServiceManager!.CompanyService.UndoDeletedCompany(companyId);
                if (isSuccess)
                {
                    await GetAllDeletedCompanies();
                }
            }
        }
        private async Task<DialogResult>SetConfirmDialog()
        {
            var settingsDialog = new SettingDialogParameters<ConfirmComponent>(DialogService!,"Confirm", "Do you want to delete this company?", "Delete", Color.Error);

            return await settingsDialog.SetConfirmDialog();
           
        }
        private async Task<DialogResult> SetUndoConfirmDialog()
        {
            var settingsDialog = new SettingDialogParameters<ConfirmComponent>(DialogService!, "Confirm", "Do you want to undo this company?", "Delete", Color.Error);

            return await settingsDialog.SetConfirmDialog();

        }
        public void NavigateToCreateCompanyPage()
        {
            NavigationManager!.NavigateTo("/company/create", false);
        }
        public void NavigateToUpdateCompanyPage(Guid companyId)
        {
            NavigationManager!.NavigateTo("/company/update/"+companyId, false);
        }
        public async Task ShowDetails(Guid companyId)
        {
            Company tmpCompany = Companies.First(f => f.Id == companyId);
         //   tmpCompany.Employees = new ObservableCollection<Employee>(await ServiceManager!.CompanyService.GetAllEmployeesAsync(companyId));
            tmpCompany.ShowDetails = !tmpCompany.ShowDetails;
        }

        public bool FilterFunc1(Company element) => FilterFunc(element, SearchStringCompanies);
        public bool FilterFunc2(Company element) => FilterFunc(element, SearchStringArchCompanies);
        public bool FilterFunc3(Job element) => FilterFuncCompanyJobs(element, SearchStringCompanyJobs);
        public bool FilterFunc4(Job element) => FilterFuncCompanyJobs(element, SearchStringArchCompanyJobs);

        private bool FilterFunc(Company element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.Name! != null && element.Name!.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        }
        private bool FilterFuncCompanyJobs(Job element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.Name! != null && element.Name!.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        public ObservableCollection<Company> Companies
        {
            get { return _companies; }
            set { SetValue(ref _companies, value); }
        }
        public String SearchStringCompanies
        {
            get { return _searchStringCompanies!; }
            set { SetValue(ref _searchStringCompanies, value); }
        }
        public String SearchStringArchCompanies
        {
            get { return _searchStringArchCompanies!; }
            set { SetValue(ref _searchStringArchCompanies, value); }
        }
        public String SearchStringCompanyJobs
        {
            get { return _searchStringCompanyJobs!; }
            set { SetValue(ref _searchStringCompanyJobs, value); }
        }
        public String SearchStringArchCompanyJobs
        {
            get { return _searchStringArchCompanyJobs!; }
            set { SetValue(ref _searchStringArchCompanyJobs, value); }
        }
    }
}
