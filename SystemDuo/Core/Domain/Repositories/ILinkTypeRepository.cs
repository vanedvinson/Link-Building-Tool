using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.Core.Domain.Repositories
{
    public interface ILinkTypeRepository : IRepositoryBase<LinkType>
    {
        Task<IEnumerable<LinkType>> GetAllLinkTypesAsync();
    }
}
