using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.Core.Services.Abstractions
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAllClientsAsync();
        Task<IEnumerable<Client>> GetAllDeletedClientsAsync();
        Task<Client> GetClientByIdAsync(Guid clientId);
        Task<bool> CreateClient(Client client);
        Task<bool> DeleteClient(Guid clientId);
        Task<bool> UpdateClient(Client client);
        Task<bool> UndoDeletedClient(Guid clientId);
    }
}
