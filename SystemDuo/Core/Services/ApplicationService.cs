using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Domain.Repositories;
using SystemDuo.Core.Services.Abstractions;

namespace SystemDuo.Core.Services
{
    public class ApplicationService:IApplicationService
    {
        private readonly IRepositoryManager _repositoryManager;
        public ApplicationService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<bool> SendJobApplicationAsync(Application candidateApplication)
        {
            
            _repositoryManager.ApplicationRepository.CreateCandidateApplication(candidateApplication);
           return await _repositoryManager.UnitOfWork.SaveChangesAsync()==1;
        }
        public async Task<IEnumerable<Application>>GetApplicationsByJobId(Guid jobId)
        {
            return await _repositoryManager.ApplicationRepository.GetAllCandidateApplicationsByJobIdAsync(jobId);
            

        }
        public async Task<bool> CreateApplicationCommentAsync(ApplicationComments applicationComments)
        {
            _repositoryManager.ApplicationCommentsRepository.CreateApplicationComments(applicationComments);
        
            return await _repositoryManager.UnitOfWork.SaveChangesAsync()==1 ;
        }
    }
}
