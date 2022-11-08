using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.Core.Services.Abstractions
{
    public interface IApplicationService
    {
        Task<bool> SendJobApplicationAsync(Application candidateApplication);
        Task<IEnumerable<Application>> GetApplicationsByJobId(Guid jobId);
        Task<bool> CreateApplicationCommentAsync(ApplicationComments applicationComments);
    }
}
