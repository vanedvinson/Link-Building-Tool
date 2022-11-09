using LinkBuildingTool.Core.Domain.Entities;
using LinkBuildingTool.Core.Domain.Repositories;
using LinkBuildingTool.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LinkBuildingTool.Core.Persistence.Repositories
{
    public class WebmasterRepository : RepositoryBase<Webmaster>, IWebmasterRepository
    {
        public WebmasterRepository(RepositoryDbContext repositoryDbContext) : base(repositoryDbContext)
        {

        }

        public void CreateWebmaster(Webmaster webmaster)
        {
            Create(webmaster);
        }

        public void DeleteWebmaster(Webmaster webmaster)
        {
            Delete(webmaster);
        }

        public Task<IEnumerable<Webmaster>> GetAllDeletedWebmastersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Webmaster>> GetAllWebmastersAsync()
        {
            var webmasters = await FindByCondition(c => c.DeletedAt == null).ToListAsync();
            return webmasters;
        }

        public async Task<Webmaster> GetWebmasterByIdAsync(Guid webmasterId)
        {
            var webmaster = await FindByCondition(c => c.Id.Equals(webmasterId)).FirstOrDefaultAsync();
            return webmaster!;
        }

        public void UpdateWebmaster(Webmaster webmaster)
        {
            Update(webmaster);
        }
    }
}
