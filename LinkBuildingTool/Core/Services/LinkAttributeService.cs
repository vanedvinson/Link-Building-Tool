using LinkBuildingTool.Core.Domain.Entities;
using LinkBuildingTool.Core.Domain.Repositories;
using LinkBuildingTool.Core.Services.Abstractions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LinkBuildingTool.Core.Services
{
    public class LinkAttributeService : ILinkAttributeService
    {
        private readonly IRepositoryManager _repositoryManager;

        public LinkAttributeService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<LinkAttribute>> GetAllLinkAttributesAsync()
        {
            return await _repositoryManager.LinkAttributeRepository.GetAllLinkAttributesAsync();
        }
    }
}
