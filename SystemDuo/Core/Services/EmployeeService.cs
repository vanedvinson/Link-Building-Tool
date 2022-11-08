using Microsoft.AspNetCore.Identity;
using SystemDuo.Core.Domain;
using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Domain.Repositories;
using SystemDuo.Core.Persistence.Repositories;
using SystemDuo.Core.Services.Abstractions;

namespace SystemDuo.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly UserManager<User> _userManager;
        public EmployeeService(IRepositoryManager repositoryManager,UserManager<User> userManager)
        {
            _userManager = userManager;
            _repositoryManager = repositoryManager;
        }

        public async Task<bool> CreateEmployee(Employee employee,Job selectedJob)
        {
   
            //_repositoryManager.EmployeeRepository.Create(employee);
            //var res=await _repositoryManager.UnitOfWork.SaveChangesAsync()==1;

            //if (res)
            //{
            //    _repositoryManager.EmployeeJobRepository.CreateEmployeeJob(new EmployeeJob
            //    {
            //        Employee = employee,
            //        Job = selectedJob,
            //        StartDate = employee.HireDate

            //    });
            //    await _repositoryManager.UnitOfWork.SaveChangesAsync();
            //    employee.User!.IsWorking = true;
            //    await _userManager.UpdateAsync(employee.User);
            //}
            return true; //TODO change later
        }

        public Task<bool> DeleteEmployee(Guid employeeId)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> EndEmployeeJob(EmployeeJob empJob)
        {
            empJob.User!.IsWorking = false;
            empJob.EndDate = DateTime.UtcNow;
             _repositoryManager.EmployeeJobRepository.UpdateEmployeeJob(empJob);
            var isUpdated = await _repositoryManager.UnitOfWork.SaveChangesAsync()==1;
            if (isUpdated)
            {
                var res = await _userManager.UpdateAsync(empJob.User);
                if (res.Succeeded)
                   return true;
                return false;
            }
            return false;

        }
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            var res = await _repositoryManager.EmployeeRepository.GetAllEmployeesAsync();
            return res;
        }

        public async Task<IEnumerable<EmployeeJob>> GetEmployeeJobAsync(string userId)
        {
            var res = await _repositoryManager.EmployeeJobRepository.GetEmployeeJobsAsync(userId);
            return res;
        }

        public Task<bool> UpdateEmployee(Guid employeeId, Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
