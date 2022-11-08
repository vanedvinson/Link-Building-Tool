using Microsoft.EntityFrameworkCore;
using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Domain.Repositories;

namespace SystemDuo.Core.Persistence.Repositories
{
    public class JobSkillsRepository : RepositoryBase<JobSkills>, IJobSkillsRepository
    {
        public JobSkillsRepository(RepositoryDbContext dbContext) : base(dbContext)
        {

        }

        public void CreateJobSkills(JobSkills jobsSkills)
        {
            Create(jobsSkills);
        }

        public void DeleteJobSkills(JobSkills jobsSkills)
        {
            Delete(jobsSkills);
        }

        public async Task<IEnumerable<JobSkills>> GetAllJobsSkillsAsync(Guid jobId)
        {
            var res = await FindByCondition(x => x.JobId.Equals(jobId)).Include(s=>s.Skill).ToListAsync();
            return res;
        }

        public Task<JobSkills> GetJobSkillsByIdAsync(Guid jobSkillId)
        {
            throw new NotImplementedException();
        }

        public void UpdateJobSkills(JobSkills jobsSkills)
        {
            throw new NotImplementedException();
        }
    }
}
