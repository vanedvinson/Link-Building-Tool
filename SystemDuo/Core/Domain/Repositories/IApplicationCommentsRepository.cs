using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.Core.Domain.Repositories
{
    public interface IApplicationCommentsRepository:IRepositoryBase<ApplicationComments>
    {
        Task<IEnumerable<ApplicationComments>> GetApplicationComments(Guid candidateApplicationId);
        void CreateApplicationComments(ApplicationComments applicationComments);
        void UpdateApplicationComments(ApplicationComments applicationComments);
    }
}
