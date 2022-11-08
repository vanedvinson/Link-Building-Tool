using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Domain.Repositories;
using SystemDuo.Data;
using Microsoft.EntityFrameworkCore;

namespace SystemDuo.Core.Persistence.Repositories
{
    public class ClientTypeRepository : RepositoryBase<ClientType>, IClientTypeRepository
    {
        public ClientTypeRepository(RepositoryDbContext repositoryDbContext) : base(repositoryDbContext)
        {

        }

        public async Task<IEnumerable<ClientType>> GetAllClientTypesAsync()
        {
            var clientTypes = await FindByCondition(c => c.Id != Guid.Empty).ToListAsync();
            return clientTypes;
        }

        public async Task<ClientType> GetClientTypeByIdAsync(Guid clientTypeId)
        {
            var clientType = await FindByCondition(c => c.Id.Equals(clientTypeId)).FirstOrDefaultAsync();
            return clientType!;
        }
    }
}
