using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.Core.Domain.Repositories
{
    public interface IJobCategoryRepository: IRepositoryBase<Category>
    {
        Task<IEnumerable<Category>> GetAllJobsCategoryAsync();
        Task<Category> GetJobCategoryByIdAsync(Guid jobCategoryId);      
        void CreateJobCategory(Category jobCategory);
        void DeleteJobCategory(Category jobCategory);
        void UpdateJobCategory(Category jobCategory);
    }
}
