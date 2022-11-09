using LinkBuildingTool.Core.Domain.Entities;

namespace LinkBuildingTool.Core.Domain.Repositories
{
    public interface ILinkTypeRepository : IRepositoryBase<LinkType>
    {
        Task<IEnumerable<LinkType>> GetAllLinkTypesAsync();
    }
}
