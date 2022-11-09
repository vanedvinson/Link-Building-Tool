using LinkBuildingTool.Core.Domain.Entities;

namespace LinkBuildingTool.Core.Domain.Repositories
{
    public interface ITodoRepository : IRepositoryBase<Todo>
    {
        Task<IEnumerable<Todo>> GetAllTodosAsync();
        Task<IEnumerable<Todo>> GetAllDeletedTodosAsync();
        Task<Todo> GetTodoByIdAsync(Guid todo);
        void CreateTodo(Todo todo);
        void DeleteTodo(Todo todo);
        void UpdateTodo(Todo todo);
    }
}
