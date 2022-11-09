using LinkBuildingTool.Core.Domain.Entities;

namespace LinkBuildingTool.Core.Domain.Repositories
{
    public interface IClientRepository : IRepositoryBase<Client>
    {
        Task<IEnumerable<Client>> GetAllClientsAsync();
        Task<IEnumerable<Client>> GetAllDeletedClientsAsync();
        Task<Client> GetClientByIdAsync(Guid clientId);
        void CreateClient(Client client);
        void DeleteClient(Client client);
        void UpdateClient(Client client);
    }
}
