using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Dto;

namespace SystemDuo.Core.Services.Abstractions
{
    public interface IJobService
    {
        Task<IEnumerable<Job>> GetAllJobsByCompanyIdAsync(Guid companyId);
        Task<IEnumerable<Job>> GetAllJobsAsync();
        Task<IEnumerable<Job>> GetAllInactiveJobsAsync();
        Task<IEnumerable<Job>> GetJobsByCategoryAsync(Category cat);
        Task<Job> GetJobByIdAsync(Guid jobId);

        Task<IEnumerable<Location>> GetAllJobLocationsAsync();
        Task<IEnumerable<Location>> GetAllDeletedLocationsAsync();
       
        Task<bool> AcceptApplication(Application application);
        Task<bool> RejectApplication(Application application);
        Task<bool> HireApplicant(Application application);
        Task<bool> UndoRejectionApplication(Application application);
        Task<bool> CreateJob(JobForCreationDto job);
        Task<bool> DeleteJob(Guid jobId);
        Task<bool> UndoDeleteJob(Guid jobId);
       // Task<bool> UpdateJob(Guid jobId, Job job);
        Task<bool> CreateLocation(Location jobLocation);
        Task<bool> DeleteLocation(Guid jobLocation);
        Task<bool> UpdateLocation(Location jobLocation);
        Task<bool> UndoDeletedLocation(Guid locationId);


        Task<bool> UpdateJob(JobForCreationDto job);
        //Task<bool> CreateJobLocation(JobLocation jobLocation);
        //Task<bool> DeleteJobLocation(Guid jobLocation);
        //Task<bool> UpdateJobLocation(JobLocation jobLocation);

    }
}
