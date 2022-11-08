using SystemDuo.Core.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SystemDuo.Core.Domain.Repositories
{
    public interface IWebmasterRepository : IRepositoryBase<Webmaster>
    {
        Task<IEnumerable<Webmaster>> GetAllWebmastersAsync();
        Task<IEnumerable<Webmaster>> GetAllDeletedWebmastersAsync();
        Task<Webmaster> GetWebmasterByIdAsync(Guid webmasterId);
        void CreateWebmaster(Webmaster webmaster);
        void DeleteWebmaster(Webmaster webmaster);
        void UpdateWebmaster(Webmaster webmaster);
    }
}
