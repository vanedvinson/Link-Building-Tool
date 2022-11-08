using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.Core.Domain.Repositories
{
    public interface IJobLocationRepository:IRepositoryBase<Location>
    {
        Task<IEnumerable<Location>> GetAllJobLocationsAsync();
        Task<IEnumerable<Location>> GetAllDeletedJobLocationsAsync();
        Task<Location> GetJobLocationByIdAsync(Guid jobCategoryId);
        void CreateJobLocation(Location jobLocation);
        void DeleteJobLocation(Location jobLocation);
        void UpdateJobLocation(Location jobLocation);
    }
}
