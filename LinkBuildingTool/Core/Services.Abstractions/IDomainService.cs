using LinkBuildingTool.Core.Domain.Entities;

namespace LinkBuildingTool.Core.Services.Abstractions
{
    public interface IDomainService
    {
        Task<IEnumerable<ClientDomain>> GetAllDomainsAsync();
        Task<IEnumerable<ClientDomain>> GetAllDeletedDomainsAsync();
        Task<ClientDomain> GetDomainByIdAsync(Guid domainId);
        Task<bool> CreateDomain(ClientDomain domain);
        Task<bool> DeleteDomain(Guid domainId);
        Task<bool> UpdateDomain(ClientDomain domain);
        Task<bool> UndoDeletedDomain(Guid domainId);
    }
}
