using Microsoft.EntityFrameworkCore;
using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Domain.Repositories;

namespace SystemDuo.Core.Persistence.Repositories
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryDbContext repositoryDbContext) : base(repositoryDbContext)
        {

        }
        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            var companies = await FindByCondition(c=>c.DeletedAt==null).Include(c=>c.Jobs).ToListAsync();
            return companies;
        }
        public async Task<IEnumerable<Company>> GetAllDeletedCompaniesAsync()
        {
            var companies = await FindByCondition(c => c.DeletedAt!= null).Include(c => c.Jobs).ToListAsync();
            return companies;
        }
        public void CreateCompany(Company company)
        {
            Create(company);
        }

        public void DeleteCompany(Company company)
        {
            Delete(company);
        }
     
        public void UpdateCompany(Company company)
        {
            Update(company);
        }

        public  async Task<Company> GetCompanyByIdAsync(Guid companyId)
        {
            var company = await FindByCondition(c=>c.Id.Equals(companyId)).Include(c=>c.Category).FirstOrDefaultAsync();
            return company!;
        }
    }
}
