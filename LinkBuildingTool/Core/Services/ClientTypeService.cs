using LinkBuildingTool.Core.Domain.Entities;
using LinkBuildingTool.Core.Domain.Repositories;
using LinkBuildingTool.Core.Services.Abstractions;

namespace LinkBuildingTool.Core.Services
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
