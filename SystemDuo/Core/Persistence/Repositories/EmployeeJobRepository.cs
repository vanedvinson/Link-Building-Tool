using Microsoft.EntityFrameworkCore;
using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Domain.Repositories;

namespace SystemDuo.Core.Persistence.Repositories
{
    public class EmployeeJobRepository : RepositoryBase<EmployeeJob>, IEmployeeJobRepository
    {
        public EmployeeJobRepository(RepositoryDbContext dbContext) : base(dbContext) { }
        public void CreateEmployeeJob(EmployeeJob employeeJob)
        {
            Create(employeeJob);
        }

        public async Task<IEnumerable<EmployeeJob>> GetAllEmployeebyCompanyIdAsync(Guid companyId)
        {
            
           return await FindByCondition(e => e.Job.CompanyId.Equals(companyId)).Include(e => e.Job).ToListAsync();
            //foreach(var r in res)
            //{
            //    if (r. == null)
            //    {

            //    }
            //}
        }

        public async Task<IEnumerable<EmployeeJob>> GetEmployeeJobsAsync(string userId)
        {
          
          return await FindByCondition(e => e.User.Id.Equals(userId)).Include(e=>e.Job).Include(u=>u.User).ToListAsync();
        }
        public void UpdateEmployeeJob(EmployeeJob employeeJob)
        {
            Update(employeeJob);
        }
    }
}
