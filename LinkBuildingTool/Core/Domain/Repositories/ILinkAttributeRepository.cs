using LinkBuildingTool.Core.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LinkBuildingTool.Core.Domain.Repositories
{
    public interface ILinkAttributeRepository : IRepositoryBase<LinkAttribute>
    {
        Task<IEnumerable<LinkAttribute>> GetAllLinkAttributesAsync();
    }
}
