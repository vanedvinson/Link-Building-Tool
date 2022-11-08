using Microsoft.EntityFrameworkCore;
using SystemDuo.Core.Domain;
using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Domain.Repositories;

namespace SystemDuo.Core.Persistence.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryDbContext dbContext) : base(dbContext) { }
       

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await FindAll().Include(e=>e.User).ToListAsync();
        }

      
        public async Task<Employee> GetEmployeeByIdAsync(Guid employeeId)
        {
           var res= await FindByCondition(e => e.Id.Equals(employeeId)).FirstOrDefaultAsync();
           return res!;
        }
        public void CreateEmployee(Employee employee)
        {
            Create(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            Delete(employee);
        }
        public void UpdateEmployee(Employee employee)
        {
            Update(employee);
        }

        public async Task<Employee> GetEmployeeByUserIdAsync(string userId)
        {
            var res = await FindByCondition(e => e.UserId!.Equals(userId)).FirstOrDefaultAsync();
            return res!;
        }
    }
}
