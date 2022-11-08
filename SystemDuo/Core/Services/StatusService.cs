using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Domain.Repositories;
using SystemDuo.Core.Services.Abstractions;

namespace SystemDuo.Core.Services
{
    public class StatusService : IStatusService
    {
        private readonly IRepositoryManager _repositoryManager;

        public StatusService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<Status>> GetAllStatusesAsync()
        {
            return await _repositoryManager.StatusRepository.GetAllStatusesTypesAsync();
        }

        public async Task<Status> GetStatusByIdAsync(Guid statusId)
        {
            var status = await _repositoryManager.StatusRepository.GetStatusByIdAsync(statusId);
            return status;
        }
    }
}
