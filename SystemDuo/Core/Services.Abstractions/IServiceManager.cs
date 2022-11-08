namespace SystemDuo.Core.Services.Abstractions
{
    public interface IServiceManager
    {
        IJobService JobService { get; }
        ICompanyService CompanyService { get; } 
        ISkillsService SkillService { get; }
        ICategoryService JobCategoryService { get; }
        IUserService UserService { get; }
        IEmployeeService EmployeeService { get; }
        IApplicationService ApplicationService { get; }
        IUserCalendarService UserCalendarService { get; }
       
    }
}
