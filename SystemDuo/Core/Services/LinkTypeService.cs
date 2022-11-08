using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Domain.Repositories;
using SystemDuo.Core.Services.Abstractions;

namespace SystemDuo.Core.Services
{
    public class LinkTypeService : ILinkTypeService
    {
        private readonly IRepositoryManager _repositoryManager;

        public LinkTypeService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<LinkType>> GetAllLinkTypesAsync()
        {
            return await _repositoryManager.LinkTypeRepository.GetAllLinkTypesAsync();
        }
    }
}
