using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Domain.Repositories;

namespace SystemDuo.Core.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();       
        Task<bool> CreateCategory(Category category);
        Task<bool> DeleteCategory(Guid categoryId);
        Task<bool> UpdateCategory(Category category);
    }
}
