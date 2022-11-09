using LinkBuildingTool.Core.Domain.Entities;
using LinkBuildingTool.Core.Domain.Repositories;
using LinkBuildingTool.Data;
using Microsoft.EntityFrameworkCore;

namespace LinkBuildingTool.Core.Persistence.Repositories
{
    public class LinkTypeRepository : RepositoryBase<LinkType>, ILinkTypeRepository
    {
        public LinkTypeRepository(RepositoryDbContext DbContext) : base(DbContext) 
        {

        }
        public async Task<IEnumerable<LinkType>> GetAllLinkTypesAsync()
        {
            var linkType = await FindByCondition(c => c.Name != "").ToListAsync();
            return linkType;
        }
    }
}
