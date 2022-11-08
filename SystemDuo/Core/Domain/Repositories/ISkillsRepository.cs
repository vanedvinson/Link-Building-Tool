using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.Core.Domain.Repositories
{
    public interface ISkillsRepository: IRepositoryBase<Skills>
    {
        Task<IEnumerable<Skills>> GetAllSkillsAsync();
        Task<Skills> GetSkillByIdAsync(Guid skillId);    
        void CreateSkill(Skills skills);
        void DeleteSkill(Skills skills);
        void UpdateSkill(Skills skills);


    }
}
