using LinkBuildingTool.Core.Domain.Entities;
using LinkBuildingTool.Core.Domain.Repositories;
using LinkBuildingTool.Data;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LinkBuildingTool.Core.Persistence.Repositories
{
    public class LinkAttributeRepository : RepositoryBase<LinkAttribute>, ILinkAttributeRepository
    {
        public LinkAttributeRepository(RepositoryDbContext DbContext) : base(DbContext) //TODO nece : base(DbContext)
        {
            
        }
        public async Task<IEnumerable<LinkAttribute>> GetAllLinkAttributesAsync()
        {
            var linkAttr = await FindByCondition(c => c.Name != "").ToListAsync();
            return linkAttr;
        }
    }
}
