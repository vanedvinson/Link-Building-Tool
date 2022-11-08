using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.Core.Domain.Repositories
{
    public interface IEmployeeJobRepository:IRepositoryBase<EmployeeJob>
    {
        void CreateEmployeeJob(EmployeeJob employeeJob);
        Task<IEnumerable<EmployeeJob>> GetEmployeeJobsAsync(string userId);
        Task<IEnumerable<EmployeeJob>> GetAllEmployeebyCompanyIdAsync(Guid companyId);
        void UpdateEmployeeJob(EmployeeJob employeeJob);
    }
}
