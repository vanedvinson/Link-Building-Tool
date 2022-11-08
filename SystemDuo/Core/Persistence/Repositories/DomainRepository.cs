using SystemDuo.Core.Domain.Repositories;
using SystemDuo.Core.Domain.Entities;
using SystemDuo.Data;
using Microsoft.EntityFrameworkCore;

namespace SystemDuo.Core.Persistence.Repositories
{
    public class DomainRepository : RepositoryBase<ClientDomain>, IDomainRepository
    {
        public DomainRepository(RepositoryDbContext repositoryDbContext) : base(repositoryDbContext)
        {

        }

        public void CreateDomain(ClientDomain domain)
        {
            Create(domain);
        }

        public void DeleteDomain(ClientDomain domain)
        {
            Delete(domain);
        }

        public Task<IEnumerable<ClientDomain>> GetAllDeletedDomainsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ClientDomain>> GetAllDomainsAsync()
        {
            var domains = await FindByCondition(c => c.DeletedAt == null).Include(c => c.Webmaster).ToListAsync();
            return domains;
        }

        public async Task<ClientDomain> GetDomainByIdAsync(Guid domainId)
        {
            var domain = await FindByCondition(c => c.Id.Equals(domainId)).Include(c => c.Webmaster).FirstOrDefaultAsync();
            return domain!;
        }

        public void UpdateDomain(ClientDomain domain)
        {
            Update(domain);
        }
    }
}
