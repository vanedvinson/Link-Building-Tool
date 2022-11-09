using LinkBuildingTool.Core.Domain.Entities;
using LinkBuildingTool.Core.Domain.Repositories;
using LinkBuildingTool.Core.Services.Abstractions;

namespace LinkBuildingTool.Core.Services
{
    public class DomainService : IDomainService
    {
        private readonly IRepositoryManager _repositoryManager;

        public DomainService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<bool> CreateDomain(ClientDomain domain)
        {
            _repositoryManager.DomainRepository.CreateDomain(domain);
            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteDomain(Guid domainId)
        {
            var domain = await _repositoryManager.DomainRepository.GetDomainByIdAsync(domainId);
            if (domain == null)
                return false;

            domain.DeletedAt = DateTime.UtcNow;
            _repositoryManager.DomainRepository.Update(domain);

            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<ClientDomain>> GetAllDeletedDomainsAsync()
        {
            return await _repositoryManager.DomainRepository.GetAllDeletedDomainsAsync();
        }

        public async Task<IEnumerable<ClientDomain>> GetAllDomainsAsync()
        {
            return await _repositoryManager.DomainRepository.GetAllDomainsAsync();
        }

        public async Task<ClientDomain> GetDomainByIdAsync(Guid domainId)
        {
            var domain = await _repositoryManager.DomainRepository.GetDomainByIdAsync(domainId);
            return domain;
        }

        public async Task<bool> UndoDeletedDomain(Guid domainId)
        {
            var domain = await _repositoryManager.DomainRepository.GetDomainByIdAsync(domainId);
            if (domain == null)
                return false;

            domain.DeletedAt = null;
            _repositoryManager.DomainRepository.Update(domain);

            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
        }

        public async Task<bool> UpdateDomain(ClientDomain domain)
        {
            _repositoryManager.DomainRepository.UpdateDomain(domain);

            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
        }
    }
}
