namespace SystemDuo.Core.Domain.Repositories
{
    public interface IEmployeeRepository:IRepositoryBase<Employee>
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();      
        Task<Employee> GetEmployeeByUserIdAsync(string userId); //To Check if user is already an employee in the system
        Task<Employee> GetEmployeeByIdAsync(Guid employeeId);
        void CreateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
    }
}
