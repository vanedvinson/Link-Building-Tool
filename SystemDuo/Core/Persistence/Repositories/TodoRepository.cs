using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Domain.Repositories;
using SystemDuo.Data;
using Microsoft.EntityFrameworkCore;

namespace SystemDuo.Core.Persistence.Repositories
{
    public class TodoRepository : RepositoryBase<Todo>, ITodoRepository
    {
        public TodoRepository(RepositoryDbContext repositoryDbContext) : base(repositoryDbContext)
        {

        }
        public void CreateTodo(Todo todo)
        {
            Create(todo);
        }

        public void DeleteTodo(Todo todo)
        {
            Delete(todo);
        }

        public Task<IEnumerable<Todo>> GetAllDeletedTodosAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Todo>> GetAllTodosAsync()
        {
            var todos = await FindByCondition(c => c.DeletedAt == null).Include(c => c.Client).Include(c => c.Status).Include(c => c.LinkAttribute).Include(c => c.LinkType).Include(c => c.Domain).ToListAsync();
            return todos;
        }

        public async Task<Todo> GetTodoByIdAsync(Guid todoId)
        {
            var todos = await FindByCondition(c => c.Id.Equals(todoId)).Include(c => c.Client).Include(c => c.Status).Include(c => c.LinkAttribute).Include(c => c.LinkType).Include(c => c.Domain).FirstOrDefaultAsync();
            return todos!;
        }

        public void UpdateTodo(Todo todo)
        {
            Update(todo);
        }
    }
}
