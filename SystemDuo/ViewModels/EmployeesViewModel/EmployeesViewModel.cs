using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.ObjectModel;
using SystemDuo.Core.Domain;
using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Services.Abstractions;

namespace SystemDuo.ViewModels
{
    public class EmployeesViewModel : BaseViewModel
    {
        private ObservableCollection<Employee> _employees = new();
       
        public string? searchString { get; set; }
        protected override async Task OnInitializedAsync()
        {

            PropertyChanged += async (sender, e) =>
            {
                await InvokeAsync(() =>
                {
                    StateHasChanged();
                });

            };
          
            await GetAllEmployees();


        }
        public async Task GetAllEmployees()
        {
            var employees = await ServiceManager!.EmployeeService.GetAllEmployeesAsync();
            if (employees != null)
                _employees = new ObservableCollection<Employee>(employees);
        }
        public void NavigateToNewEmployee()
        {
            NavigationManager!.NavigateTo("/create/employee");
        }
        public async Task ShowEmployeeJobDetails(Guid employeeId)
        {
            Employee tmpEmployee = Employees.First(f => f.Id == employeeId);
        //    tmpEmployee.EmployeeJob = new ObservableCollection<EmployeeJob>(await ServiceManager!.EmployeeService.GetEmployeeJobAsync(employeeId));
            tmpEmployee.ShowDetails = !tmpEmployee.ShowDetails;
        }
        public async Task EndEmployeeJob(EmployeeJob empJob)
        {
            var res= await ServiceManager!.EmployeeService.EndEmployeeJob(empJob);
            if (res)
            {
                //add success message
            }
        }
        public ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            set { SetValue(ref _employees, value); }
        }
    }
}
