using LinkBuildingTool.Core.Domain.Entities;

namespace LinkBuildingTool.Core.Domain.Repositories
{
    public interface IStatusRepository : IRepositoryBase<Status>
    {
        Task<IEnumerable<Status>> GetAllStatusesTypesAsync();
        Task<Status> GetStatusByIdAsync(Guid statusId);
    }
}
