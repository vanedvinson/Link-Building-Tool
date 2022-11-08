using Microsoft.EntityFrameworkCore;
using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Domain.Repositories;

namespace SystemDuo.Core.Persistence.Repositories
{
    public class JobCategoryRepository : RepositoryBase<Category>, IJobCategoryRepository
    {
        public JobCategoryRepository(RepositoryDbContext dbContext) : base(dbContext) { }
        public void CreateJobCategory(Category jobCategory)
        {
            Create(jobCategory);
        }

        public void DeleteJobCategory(Category jobCategory)
        {
            Delete(jobCategory);
        }

        public async Task<IEnumerable<Category>> GetAllJobsCategoryAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Category> GetJobCategoryByIdAsync(Guid jobCategoryId)
        {
            var res= await FindByCondition(jc=>jc.Id.Equals(jobCategoryId)).FirstOrDefaultAsync();
            return res!;
        }

        public void UpdateJobCategory(Category jobCategory)
        {
           Update(jobCategory);
        }
    }
}
