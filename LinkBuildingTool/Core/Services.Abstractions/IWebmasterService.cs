using LinkBuildingTool.Core.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LinkBuildingTool.Core.Services.Abstractions
{
    public interface IWebmasterService
    {
        Task<IEnumerable<Webmaster>> GetAllWebmastersAsync();
        Task<IEnumerable<Webmaster>> GetAllDeletedWebmastersAsync();
        Task<Webmaster> GetWebmasterByIdAsync(Guid webmasterId);
        Task<bool> CreateWebmaster(Webmaster webmaster);
        Task<bool> DeleteWebmaster(Guid webmasterId);
        Task<bool> UpdateWebmaster(Webmaster webmaster);
        Task<bool> UndoDeletedWebmaster(Guid webmasterId);
    }
}
