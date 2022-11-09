using LinkBuildingTool.Core.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LinkBuildingTool.Core.Services.Abstractions
{
    public interface ILinkAttributeService
    {
        Task<IEnumerable<LinkAttribute>> GetAllLinkAttributesAsync();
    }
}
