using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Domain.Repositories;
using SystemDuo.Data;
using Microsoft.EntityFrameworkCore;

namespace SystemDuo.Core.Persistence.Repositories
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
