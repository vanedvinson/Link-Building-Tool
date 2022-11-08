using SystemDuo.Core.Domain;
using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.Core.Services.Abstractions
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<IEnumerable<EmployeeJob>> GetEmployeeJobAsync(string userId);
        Task<bool> CreateEmployee(Employee employee,Job selectedJob);
        Task<bool> DeleteEmployee(Guid employeeId);
        Task<bool> UpdateEmployee(Guid employeeId, Employee employee);
        Task<bool> EndEmployeeJob(EmployeeJob emJob);
    }
}
