using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Domain.Repositories;
using SystemDuo.Data;
using Microsoft.EntityFrameworkCore;

namespace SystemDuo.Core.Persistence.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(RepositoryDbContext repositoryDbContext) : base(repositoryDbContext)
        {

        }

        public void CreateClient(Client client)
        {
            Create(client);
        }

        public void DeleteClient(Client client)
        {
            Delete(client);
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            var clients = await FindByCondition(c => c.DeletedAt == null).Include(c => c.Type).ToListAsync();
            return clients;
        }

        public Task<IEnumerable<Client>> GetAllDeletedClientsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Client> GetClientByIdAsync(Guid clientId)
        {
            var client = await FindByCondition(c => c.Id.Equals(clientId)).Include(c => c.Type).FirstOrDefaultAsync();
            return client!;
        }

        public void UpdateClient(Client client)
        {
            Update(client);
        }
    }
}
