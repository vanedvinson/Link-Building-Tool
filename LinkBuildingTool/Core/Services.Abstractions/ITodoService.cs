using LinkBuildingTool.Core.Domain.Entities;

namespace LinkBuildingTool.Core.Services.Abstractions
{
    public interface ITodoService
    {
        Task<IEnumerable<Todo>> GetAllWTodosAsync();
        Task<IEnumerable<Todo>> GetAllDeletedTodosAsync();
        Task<Todo> GetTodoByIdAsync(Guid todoId);
        Task<bool> CreateTodo(Todo todo);
        Task<bool> DeleteTodor(Guid todoId);
        Task<bool> UpdateTodo(Todo todo);
        Task<bool> UndoDeletedTodo(Guid todoId);
    }
}
