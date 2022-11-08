using Microsoft.EntityFrameworkCore;
using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Domain.Repositories;

namespace SystemDuo.Core.Persistence.Repositories
{
    public class ApplicationCommentsRepository : RepositoryBase<ApplicationComments>, IApplicationCommentsRepository
    {
        public ApplicationCommentsRepository(RepositoryDbContext dbContext) : base(dbContext) { }
        public void CreateApplicationComments(ApplicationComments applicationComments)
        {
            Create(applicationComments);
        }

        public async Task<IEnumerable<ApplicationComments>> GetApplicationComments(Guid candidateApplicationId)
        {
            var res = await FindByCondition(ca => ca.Id.Equals(candidateApplicationId)).ToListAsync();
            return res!;
        }

        public void UpdateApplicationComments(ApplicationComments applicationComments)
        {
            Update(applicationComments);
        }
    }
}
