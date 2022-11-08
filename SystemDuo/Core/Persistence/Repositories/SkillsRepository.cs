using Microsoft.EntityFrameworkCore;
using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Domain.Repositories;

namespace SystemDuo.Core.Persistence.Repositories
{
    public class SkillsRepository : RepositoryBase<Skills>, ISkillsRepository
    {
        public SkillsRepository(RepositoryDbContext repositoryDbContext) : base(repositoryDbContext)
        {

        }
        public async Task<IEnumerable<Skills>> GetAllSkillsAsync()
        {
            return await FindAll().ToListAsync();

        }

        public async Task<Skills> GetSkillByIdAsync(Guid skillId)
        {
            var skill = await FindByCondition(s => s.Id.Equals(skillId)).FirstOrDefaultAsync();
            if (skill != null)
                return skill;
            return new Skills(); //TODO CHANGE THIS
        }
        public void CreateSkill(Skills skills)
        {
            Create(skills);
        }

        public void DeleteSkill(Skills skills)
        {
            Delete(skills);
        }

       

        public void UpdateSkill(Skills skills)
        {
            Update(skills);
        }
    }
}
