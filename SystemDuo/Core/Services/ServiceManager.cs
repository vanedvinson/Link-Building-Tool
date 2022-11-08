using Microsoft.AspNetCore.Identity;
using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Domain.Repositories;
using SystemDuo.Core.Services.Abstractions;

namespace SystemDuo.Core.Services
{
    public class ServiceManager:IServiceManager
    {
        private readonly Lazy<IJobService> _lazyJobService; 
        private readonly Lazy<ICompanyService> _lazyCompanyService; 
        private readonly Lazy<ISkillsService> _lazySkillService; 
        private readonly Lazy<ICategoryService> _lazyJobCategoryService; 
        private readonly Lazy<IUserService> _lazyUserService; 
        private readonly Lazy<IEmployeeService> _lazyEmployeeService; 
        private readonly Lazy<IApplicationService> _lazyApplicationService; 
        private readonly Lazy<IUserCalendarService> _lazyUserCalendarService;
        public ServiceManager(IRepositoryManager repositoryManager,UserManager<User> userManager,IMailService mailService,RoleManager<Role> roleManager,ITokenService tokenService)
        {
            _lazyJobService = new Lazy<IJobService>(() => new JobService(repositoryManager,userManager));
            _lazyCompanyService = new Lazy<ICompanyService>(() => new CompanyService(repositoryManager));
            _lazySkillService = new Lazy<ISkillsService>(() => new SkillsService(repositoryManager));
            _lazyJobCategoryService = new Lazy<ICategoryService>(() => new CategoryService(repositoryManager));
            _lazyUserService = new Lazy<IUserService>(() => new UserService(userManager, mailService, tokenService,roleManager, repositoryManager));
            _lazyEmployeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager,userManager));
            _lazyApplicationService = new Lazy<IApplicationService>(() => new ApplicationService(repositoryManager));
            _lazyUserCalendarService = new Lazy<IUserCalendarService>(() => new UserCalendarService(repositoryManager,userManager));
        }
        public IJobService JobService => _lazyJobService.Value;
        public ICompanyService CompanyService => _lazyCompanyService.Value;
        public ISkillsService SkillService => _lazySkillService.Value;
        public ICategoryService JobCategoryService => _lazyJobCategoryService.Value;
        public IUserService UserService => _lazyUserService.Value;
        public IEmployeeService EmployeeService => _lazyEmployeeService.Value;
        public IApplicationService ApplicationService => _lazyApplicationService.Value;

        public IUserCalendarService UserCalendarService => _lazyUserCalendarService.Value;
    }
}
