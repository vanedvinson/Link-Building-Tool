using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.Core.Domain.Repositories
{
    public interface IApplicantSkillsRepository:IRepositoryBase<ApplicantSkills>
    {
        Task<IEnumerable<ApplicantSkills>> GetAllApplicantSkillsAsync(string userId);
        Task<ApplicantSkills> GetApplicantSkillsByIdAsync(Guid applicantSkillId);
        void CreateApplicantSkills(ApplicantSkills applicantSkills);
        void DeleteApplicantSkills(ApplicantSkills applicantSkills);
        void UpdateApplicantSkills(ApplicantSkills applicantSkills);
    }
}
