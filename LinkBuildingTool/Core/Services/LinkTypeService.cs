using LinkBuildingTool.Core.Domain.Entities;
using LinkBuildingTool.Core.Domain.Repositories;
using LinkBuildingTool.Core.Services.Abstractions;

namespace LinkBuildingTool.Core.Services
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
