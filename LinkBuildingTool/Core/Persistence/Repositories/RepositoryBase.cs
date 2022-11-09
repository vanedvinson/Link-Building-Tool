using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using LinkBuildingTool.Core.Domain.Repositories;

namespace LinkBuildingTool.Core.Persistence.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly RepositoryDbContext RepositoryContext;
        public RepositoryBase(RepositoryDbContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        public IQueryable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression);
        }
        public void Create(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);

        }
        public void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }
    }

}
