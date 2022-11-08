using Microsoft.EntityFrameworkCore;
using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Domain.Repositories;

namespace SystemDuo.Core.Persistence.Repositories
{
    public class JobLocationRepository : RepositoryBase<Location>, IJobLocationRepository
    {
        public JobLocationRepository(RepositoryDbContext dbContext) : base(dbContext) { }
        public void CreateJobLocation(Location jobLocation)
        {
            Create(jobLocation);
        }

        public void DeleteJobLocation(Location jobLocation)
        {
            Delete(jobLocation);
        }

        public async Task<IEnumerable<Location>> GetAllJobLocationsAsync()
        {
            return await FindByCondition(x=>x.DeletedAt==null).ToListAsync();
        }
        public async Task<IEnumerable<Location>> GetAllDeletedJobLocationsAsync()
        {
            return await FindByCondition(x => x.DeletedAt != null).ToListAsync();
        }

        public async Task<Location> GetJobLocationByIdAsync(Guid jobLocationId)
        {
            var res = await FindByCondition(x=>x.Id == jobLocationId).FirstOrDefaultAsync();
            return res!;
        }

        public void UpdateJobLocation(Location jobLocation)
        {
            Update(jobLocation);
        }
    }
}
