namespace SystemDuo.Core.Domain.Repositories
{
    public interface IRepositoryManager
    {
        IUnitOfWork UnitOfWork { get; }
        IJobRepository JobsRepository{ get; }
        IJobSkillsRepository JobsSkillsRepository{ get; }
        ICompanyRepository CompanyRepository{ get; }
        ISkillsRepository SkillsRepository{ get; }
        IJobCategoryRepository JobsCategoryRepository{ get; }
        IApplicationRepository ApplicationRepository{ get; }
        IApplicationCommentsRepository ApplicationCommentsRepository{ get; }
        IEmployeeRepository EmployeeRepository{ get; }
        IEmployeeJobRepository EmployeeJobRepository{ get; }
        IJobLocationRepository JobLocationRepository{ get; }
        IUserCalendarRepository UserCalendarRepository{ get; }
    }
}
