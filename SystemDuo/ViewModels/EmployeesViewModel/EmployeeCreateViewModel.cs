using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.ObjectModel;
using SystemDuo.Components.Dialogs;
using SystemDuo.Core.Domain;
using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.ViewModels
{
    public class EmployeeCreateViewModel:BaseViewModel
    {
        private ObservableCollection<Company> _companies = new();
    
        private Company _selectedCompany = new();

        private Job _selectedJob = new();
        private Employee _newEmployee = new();
        private ObservableCollection<User> _candidates = new();
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
            await GetAllCandidates();
          

        }
        public async Task CreateEmployee()
        {
                     
           var res = await ServiceManager!.EmployeeService.CreateEmployee(NewEmployee!,SelectedJob);
                    if (res)
                    {
                        SelectedCompany = new();
                        SelectedJob = new();
                        
                        NewEmployee = new();
                        NavigationManager!.NavigateTo("/employees", false);
            }
                   
          
        }
        public async Task GetAllCompanies()
        {
            var companies = await ServiceManager!.CompanyService.GetAllCompaniesAsync();
            if (companies != null)
                _companies = new ObservableCollection<Company>(companies);
        }

        public async Task GetAllCandidates()
        {
            var candidates = await ServiceManager!.UserService.GetFreeCandidatesAsync();
            if (candidates != null)
                _candidates = new ObservableCollection<User>(candidates);

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

        public Job SelectedJob
        {
            get { return _selectedJob; }
            set { SetValue(ref _selectedJob, value); }
        }
        public Employee NewEmployee
        {
            get { return _newEmployee; }
            set { SetValue(ref _newEmployee, value); }
        }
        public ObservableCollection<User> Candidates
        {
            get { return _candidates; }
            set { SetValue(ref _candidates, value); }
        }

    }
}
