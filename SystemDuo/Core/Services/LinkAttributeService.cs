using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Domain.Repositories;
using SystemDuo.Core.Services.Abstractions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SystemDuo.Core.Services
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
