using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Domain.Repositories;
using SystemDuo.Core.Services.Abstractions;

namespace SystemDuo.Core.Services
{
    public class ClientTypeService : IClientTypeService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ClientTypeService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<ClientType>> GetAllClientTypesAsync()
        {
            return await _repositoryManager.ClientTypeRepository.GetAllClientTypesAsync();
        }

        public async Task<ClientType> GetClientTypeByIdAsync(Guid clientTypeId)
        {
            var clientType = await _repositoryManager.ClientTypeRepository.GetClientTypeByIdAsync(clientTypeId);
            return clientType;
        }
    }
}
