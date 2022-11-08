using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Domain.Repositories;
using SystemDuo.Core.Services.Abstractions;

namespace SystemDuo.Core.Services
{
    public class TodoService : ITodoService
    {
        private readonly IRepositoryManager _repositoryManager;

        public TodoService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<bool> CreateTodo(Todo todo)
        {
            _repositoryManager.TodoRepository.CreateTodo(todo);
            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteTodor(Guid todoId)
        {
            var todo = await _repositoryManager.TodoRepository.GetTodoByIdAsync(todoId);
            if (todo == null)
                return false;

            todo.DeletedAt = DateTime.UtcNow;
            _repositoryManager.TodoRepository.Update(todo);

            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<Todo>> GetAllDeletedTodosAsync()
        {
            return await _repositoryManager.TodoRepository.GetAllDeletedTodosAsync();
        }

        public async Task<IEnumerable<Todo>> GetAllWTodosAsync()
        {
            return await _repositoryManager.TodoRepository.GetAllTodosAsync();
        }

        public async Task<Todo> GetTodoByIdAsync(Guid todoId)
        {
            var todo = await _repositoryManager.TodoRepository.GetTodoByIdAsync(todoId);
            return todo;
        }

        public async Task<bool> UndoDeletedTodo(Guid todoId)
        {
            var todo = await _repositoryManager.TodoRepository.GetTodoByIdAsync(todoId);
            if (todo == null)
                return false;

            todo.DeletedAt = null;
            _repositoryManager.TodoRepository.Update(todo);

            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
        }

        public async Task<bool> UpdateTodo(Todo todo)
        {
            _repositoryManager.TodoRepository.UpdateTodo(todo);

            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
        }
    }
}
