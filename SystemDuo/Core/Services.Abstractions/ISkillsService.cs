using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.Core.Services.Abstractions
{
    public interface ISkillsService
    {
        Task<IEnumerable<Skills>> GetAllSkillsAsync();   
        Task<bool> CreateSkill(Skills skill);
        Task<bool> DeleteSkill(Skills skill);
        Task<bool> UpdateSkill(Skills skill);
    }
}
