using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.Core.Domain.Repositories
{
    public interface ICompanyRepository:IRepositoryBase<Company>
    {
        Task<IEnumerable<Company>> GetAllCompaniesAsync();
        Task<IEnumerable<Company>> GetAllDeletedCompaniesAsync();
        Task<Company> GetCompanyByIdAsync(Guid companyId);
        void CreateCompany(Company company);
        void DeleteCompany(Company company);
        void UpdateCompany(Company company);
    }
}
