using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.Core.Domain.Repositories
{
    public interface IApplicationRepository : IRepositoryBase<Application>
    {
        Task<IEnumerable<Application>> GetAllCandidateApplicationsByJobIdAsync(Guid jobId);
        Task<IEnumerable<Application>> GetAllCandidateApplicationsAsync();
        Task<Application> GetCandidateApplicationByIdAsync(Guid candidateApplicationId);
        void CreateCandidateApplication(Application candidateApplication);
        void DeleteCandidateApplication(Application candidateApplication);
        void UpdateCandidateApplication(Application candidateApplication);
    }
}
