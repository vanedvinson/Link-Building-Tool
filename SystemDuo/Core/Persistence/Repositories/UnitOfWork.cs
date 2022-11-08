using SystemDuo.Core.Domain.Repositories;

namespace SystemDuo.Core.Persistence.Repositories
{
    internal sealed class UnitOfWork : IUnitOfWork
    {
        private readonly RepositoryDbContext _dbContext;

        public UnitOfWork(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
           
           return _dbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task Dispose()
        {
            await _dbContext.DisposeAsync();
        }
    }
}
