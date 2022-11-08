using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.Core.Domain.Repositories
{
    public interface IJobRepository:IRepositoryBase<Job>
    {
        Task<IEnumerable<Job>> GetAllJobsAsync();
        Task<IEnumerable<Job>> GetAllInactiveJobsAsync();
        Task<Job> GetJobByIdAsync(Guid jobId);
        Task<IEnumerable<Job>> GetAllJobsByCompanyIdAsync(Guid companyId);
        Task<IEnumerable<Job>> GetJobsByCategoryAsync(Category cat);
        void CreateJob(Job job);
        void DeleteJob(Job job);
        void UpdateJob(Job job);
        

    }
}
