using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Domain.Repositories;
using SystemDuo.Core.Services.Abstractions;

namespace SystemDuo.Core.Services
{
    public class SkillsService : ISkillsService
    {
        private readonly IRepositoryManager _repositoryManager;
        public SkillsService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<bool> CreateSkill(Skills skill)
        {
            _repositoryManager.SkillsRepository.CreateSkill(skill);
            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteSkill(Skills skill)
        {
            //var skill = await _repositoryManager.SkillsRepository.GetSkillByIdAsync(skillId);
            //if (skill == null)
            //    return false;
            _repositoryManager.SkillsRepository.DeleteSkill(skill);

            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<Skills>> GetAllSkillsAsync()
        {
            var skills = await _repositoryManager.SkillsRepository.GetAllSkillsAsync();
            return skills;
        }

        public async Task<bool> UpdateSkill(Skills skill)
        {
            var _skill = await _repositoryManager.SkillsRepository.GetSkillByIdAsync(skill.Id);

            if (_skill == null)
                return false;
            _repositoryManager.SkillsRepository.UpdateSkill(skill);

            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
        }
    }
}
