using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.Core.Domain.Repositories
{
    public interface IJobSkillsRepository
    {
        Task<IEnumerable<JobSkills>> GetAllJobsSkillsAsync(Guid jobId);
        Task<JobSkills> GetJobSkillsByIdAsync(Guid jobSkillId);
       
        void CreateJobSkills(JobSkills jobsSkills);
        void DeleteJobSkills(JobSkills jobsSkills);
        void UpdateJobSkills(JobSkills jobsSkills);
    }
}
