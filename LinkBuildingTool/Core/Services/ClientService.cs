using LinkBuildingTool.Core.Domain.Entities;
using LinkBuildingTool.Core.Domain.Repositories;
using LinkBuildingTool.Core.Services.Abstractions;

namespace LinkBuildingTool.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ClientService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<bool> CreateClient(Client client)
        {
            _repositoryManager.ClientRepository.CreateClient(client);
            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteClient(Guid clientId)
        {
            var client = await _repositoryManager.ClientRepository.GetClientByIdAsync(clientId);
            if (client == null)
                return false;

            client.DeletedAt = DateTime.UtcNow;
            _repositoryManager.ClientRepository.Update(client);

            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return await _repositoryManager.ClientRepository.GetAllClientsAsync();
        }

        public async Task<IEnumerable<Client>> GetAllDeletedClientsAsync()
        {
            return await _repositoryManager.ClientRepository.GetAllDeletedClientsAsync();
        }

        public async Task<Client> GetClientByIdAsync(Guid clientId)
        {
            var client = await _repositoryManager.ClientRepository.GetClientByIdAsync(clientId);
            return client;
        }

        public async Task<bool> UndoDeletedClient(Guid clientId)
        {
            var client = await _repositoryManager.ClientRepository.GetClientByIdAsync(clientId);
            if (client == null)
                return false;

            client.DeletedAt = null;
            _repositoryManager.ClientRepository.Update(client);

            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
        }

        public async Task<bool> UpdateClient(Client client)
        {
            _repositoryManager.ClientRepository.UpdateClient(client);

            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
        }
    }
}
