using SystemDuo.Core.Domain;
using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.Core.Services.Abstractions
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAllCompaniesAsync();
        Task<IEnumerable<Company>> GetAllDeletedCompaniesAsync();
        Task<IEnumerable<Employee>> GetAllEmployeesAsync(Guid companyId);
        Task<Company> GetCompanyByIdAsync(Guid companyId);
        Task<bool> CreateCompany(Company company);
        Task<bool> DeleteCompany(Guid companyId);
        Task<bool> UpdateCompany(Company company);
        Task<bool> UndoDeletedCompany(Guid companyId);
    }
}
