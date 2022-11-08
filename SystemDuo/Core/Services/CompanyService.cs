using SystemDuo.Core.Domain;
using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Domain.Repositories;
using SystemDuo.Core.Services.Abstractions;

namespace SystemDuo.Core.Services
{
    public class CompanyService:ICompanyService
    {
        private readonly IRepositoryManager _repositoryManager;

        public CompanyService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<bool> CreateCompany(Company company)
        {
            _repositoryManager.CompanyRepository.CreateCompany(company);
            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteCompany(Guid companyId)
        {
            var company = await _repositoryManager.CompanyRepository.GetCompanyByIdAsync(companyId);
            if (company == null)
                return false;

            company.DeletedAt = DateTime.UtcNow;
            _repositoryManager.CompanyRepository.Update(company);

            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;

        }
        public async Task<bool> UndoDeletedCompany(Guid companyId)
        {
            var company = await _repositoryManager.CompanyRepository.GetCompanyByIdAsync(companyId);
            if (company == null)
                return false;

            company.DeletedAt = null;
            _repositoryManager.CompanyRepository.Update(company);

            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;

        }
        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            return await _repositoryManager.CompanyRepository.GetAllCompaniesAsync();
        }
        public async Task<IEnumerable<Company>> GetAllDeletedCompaniesAsync()
        {
            return await _repositoryManager.CompanyRepository.GetAllDeletedCompaniesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync(Guid companyId)
        {
            var res= await _repositoryManager.EmployeeJobRepository.GetAllEmployeebyCompanyIdAsync(companyId);
            return  new List<Employee>();
          
           

        }
        public async Task<bool> UpdateCompany(Company company)
        {
           
            _repositoryManager.CompanyRepository.UpdateCompany(company);

            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
        }
        public async Task<IEnumerable<Job>> GetJobsByCompanyId(Guid companyId)
        {
            var companyJobs = await _repositoryManager.JobsRepository.GetAllJobsByCompanyIdAsync(companyId);
            return companyJobs;

        }
        public async Task<Company> GetCompanyByIdAsync(Guid companyId)
        {
            var company = await _repositoryManager.CompanyRepository.GetCompanyByIdAsync(companyId);
            return company;
        }
    }
}
