namespace LinkBuildingTool.Core.Domain.Repositories
{
    public interface IRepositoryManager
    {
        IUnitOfWork UnitOfWork { get; }
        //IJobRepository JobsRepository{ get; }
        //IJobSkillsRepository JobsSkillsRepository{ get; }
        //ICompanyRepository CompanyRepository{ get; }
        //ISkillsRepository SkillsRepository{ get; }
        //IJobCategoryRepository JobsCategoryRepository{ get; }
        //IApplicationRepository ApplicationRepository{ get; }
        //IApplicationCommentsRepository ApplicationCommentsRepository{ get; }
        //IEmployeeRepository EmployeeRepository{ get; }
        //IEmployeeJobRepository EmployeeJobRepository{ get; }
        //IJobLocationRepository JobLocationRepository{ get; }
        //IUserCalendarRepository UserCalendarRepository{ get; }
        ILinkAttributeRepository LinkAttributeRepository { get; }
        IWebmasterRepository WebmasterRepository { get; }
        IDomainRepository DomainRepository { get; }
        ITodoRepository TodoRepository { get; }
        IClientRepository ClientRepository { get; }
        IClientTypeRepository ClientTypeRepository { get; }
        IStatusRepository StatusRepository { get; }
        ILinkTypeRepository LinkTypeRepository { get; }
    }
}
