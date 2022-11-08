using Microsoft.EntityFrameworkCore;
using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Domain.Repositories;

namespace SystemDuo.Core.Persistence.Repositories
{
    public class ApplicantSkillsRepository : RepositoryBase<ApplicantSkills>, IApplicantSkillsRepository
    {
        public ApplicantSkillsRepository(RepositoryDbContext dbContext) : base(dbContext)
        {

        }
        public void CreateApplicantSkills(ApplicantSkills applicantSkills)
        {
            Create(applicantSkills);
        }
        public void DeleteApplicantSkills(ApplicantSkills applicantSkills)
        {
            Delete(applicantSkills);
        }
        public async Task<IEnumerable<ApplicantSkills>> GetAllApplicantSkillsAsync(string userId)
        {
            var res = await FindByCondition(x => x.UserId!.Equals(userId)).Include(s=>s.Skill).ToListAsync();
            return res;
        }
        public async Task<ApplicantSkills> GetApplicantSkillsByIdAsync(Guid applicantSkillId)
        {
            var res = await FindByCondition(x => x.Id!.Equals(applicantSkillId)).Include(s => s.Skill).FirstOrDefaultAsync();
            return res!;
        }
        public void UpdateApplicantSkills(ApplicantSkills applicantSkills)
        {
            Update(applicantSkills);
        }
    }
}
