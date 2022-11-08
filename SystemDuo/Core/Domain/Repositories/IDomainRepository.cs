﻿using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.Core.Domain.Repositories
{
    public interface IDomainRepository : IRepositoryBase<ClientDomain>
    {
        Task<IEnumerable<ClientDomain>> GetAllDomainsAsync();
        Task<IEnumerable<ClientDomain>> GetAllDeletedDomainsAsync();
        Task<ClientDomain> GetDomainByIdAsync(Guid domainId);
        void CreateDomain(ClientDomain domain);
        void DeleteDomain(ClientDomain domain);
        void UpdateDomain(ClientDomain domain);
    }
}
