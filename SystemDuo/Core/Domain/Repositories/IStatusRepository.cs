using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.Core.Domain.Repositories
{
    public interface IStatusRepository : IRepositoryBase<Status>
    {
        Task<IEnumerable<Status>> GetAllStatusesTypesAsync();
        Task<Status> GetStatusByIdAsync(Guid statusId);
    }
}
