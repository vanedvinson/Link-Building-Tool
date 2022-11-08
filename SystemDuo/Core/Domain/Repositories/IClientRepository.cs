using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.Core.Domain.Repositories
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
