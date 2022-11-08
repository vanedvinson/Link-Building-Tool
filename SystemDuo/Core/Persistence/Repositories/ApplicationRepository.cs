using Microsoft.EntityFrameworkCore;
using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Domain.Repositories;

namespace SystemDuo.Core.Persistence.Repositories
{
    public class ApplicationRepository : RepositoryBase<Application>, IApplicationRepository
    {
        public ApplicationRepository(RepositoryDbContext dbContext) : base(dbContext) { }
        public void CreateCandidateApplication(Application candidateApplication)
        {
            Create(candidateApplication);
        }

        public void DeleteCandidateApplication(Application candidateApplication)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Application>> GetAllCandidateApplicationsAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<IEnumerable<Application>> GetAllCandidateApplicationsByJobIdAsync(Guid jobId)
        {
            return await FindByCondition(ca => ca.JobId.Equals(jobId)).Include(a=>a.ApplicationComments).Include(a=>a.User).ToListAsync();
        }

        public async Task<Application> GetCandidateApplicationByIdAsync(Guid candidateApplicationId)
        {
            var res=await FindByCondition(ca => ca.Id.Equals(candidateApplicationId)).Include(c=>c.Job).FirstOrDefaultAsync();
            return res!;
        }

        public void UpdateCandidateApplication(Application candidateApplication)
        {
            Update(candidateApplication);
        }
    }
}
