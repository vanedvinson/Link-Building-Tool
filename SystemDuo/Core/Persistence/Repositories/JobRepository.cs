using Microsoft.EntityFrameworkCore;
using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Domain.Repositories;

namespace SystemDuo.Core.Persistence.Repositories
{
    public class JobRepository : RepositoryBase<Job>, IJobRepository
    {
        RepositoryDbContext _dbContext;
        public JobRepository(RepositoryDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Job>> GetAllJobsAsync()
        {
          //  var jobs = await FindAll().Include(j => j.CandidateApplications).Include(j => j.Company).Include("JobSkills.Skill").Where(j => j.Company!.Category == cat).ToListAsync();

            var jobs = await FindAll().Include(j => j.CandidateApplications).ThenInclude(j=>j.User).Include(j => j.Company).ThenInclude(c => c.Category).Include("JobSkills.Skill").Where(j => j.IsActive == true).AsSplitQuery().ToListAsync();
            return jobs;
        }
        public async Task<IEnumerable<Job>> GetAllInactiveJobsAsync()
        {
            var jobs = await FindByCondition(j => j.IsActive == false).Include(j => j.CandidateApplications).Include(j => j.Company).ThenInclude(c => c.Category).Include("JobSkills.Skill").ToListAsync();
            return jobs;
        }
        public void CreateJob(Job job)
        {
            Create(job);

        }

        public void DeleteJob(Job job)
        {
            Delete(job);
        }

        public void UpdateJob(Job job)
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries().ToArray())
            {
                entry.State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
            Update(job);
        }

        public async Task<Job> GetJobByIdAsync(Guid jobId)
        {
            var job = await FindByCondition(j => j.Id == jobId).Include(a => a.AssignedTo).Include(l => l.Location).Include(j => j.Company).ThenInclude(c => c.Category).Include("JobSkills.Skill").AsNoTracking().AsSplitQuery().FirstOrDefaultAsync();
#pragma warning disable CS8603 // Possible null reference return.
            return job;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<IEnumerable<Job>> GetAllJobsByCompanyIdAsync(Guid companyId)
        {
            var jobs = await FindByCondition(j => j.CompanyId == companyId).ToListAsync();
            return jobs;
        }


        public async Task<IEnumerable<Job>> GetJobsByCategoryAsync(Category cat)
        {
            var jobs = await FindAll().Include(j => j.CandidateApplications).Include(j => j.Company).Include("JobSkills.Skill").Where(j => j.Company!.Category == cat && j.IsActive == true).ToListAsync();
            return jobs;
        }

    }
}
