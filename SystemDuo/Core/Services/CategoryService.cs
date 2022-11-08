using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Domain.Repositories;
using SystemDuo.Core.Persistence.Repositories;
using SystemDuo.Core.Services.Abstractions;

namespace SystemDuo.Core.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly IRepositoryManager _repositoryManager;

        public CategoryService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<bool> CreateCategory(Category category)
        {
             _repositoryManager.JobsCategoryRepository.CreateJobCategory(category);
            return await _repositoryManager.UnitOfWork.SaveChangesAsync()==1;
        }

        public async Task<bool> DeleteCategory(Guid jobsCategoryId)
        {
            var jobCategory = await _repositoryManager.JobsCategoryRepository.GetJobCategoryByIdAsync(jobsCategoryId);
            if (jobCategory == null)
                return false;
            _repositoryManager.JobsCategoryRepository.DeleteJobCategory(jobCategory);

            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;

        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            var jobsCategory = await _repositoryManager.JobsCategoryRepository.GetAllJobsCategoryAsync();
            return jobsCategory;
        }

       

        public async Task<bool> UpdateCategory(Category category)
        {
            var _category = await _repositoryManager.JobsCategoryRepository.GetJobCategoryByIdAsync(category.Id);
            if (_category == null)
                return false;
            _repositoryManager.JobsCategoryRepository.UpdateJobCategory(category);

            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
        }
    }
}
