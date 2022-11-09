namespace LinkBuildingTool.Core.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task Dispose();
    }
}
