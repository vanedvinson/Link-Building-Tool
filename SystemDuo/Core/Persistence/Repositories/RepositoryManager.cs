using SystemDuo.Core.Domain.Repositories;

namespace SystemDuo.Core.Persistence.Repositories
{
    public class RepositoryManager:IRepositoryManager
    {
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;
        private readonly Lazy<IJobRepository> _lazyJobRepository;
        private readonly Lazy<ICompanyRepository> _lazyCompanyRepository;
        private readonly Lazy<ISkillsRepository> _lazySkillsRepository;
        private readonly Lazy<IJobSkillsRepository> _lazyJobsSkillsRepository;
        private readonly Lazy<IJobCategoryRepository> _lazyJobsCategoryRepository;
        private readonly Lazy<IApplicationRepository> _lazyApplicationRepository;
        private readonly Lazy<IApplicationCommentsRepository> _lazyApplicationCommentsRepository;
        private readonly Lazy<IEmployeeRepository> _lazyEmployeeRepository;
        private readonly Lazy<IJobLocationRepository> _lazyJobLocationRepository;
        private readonly Lazy<IEmployeeJobRepository> _lazyEmployeeJobRepository;
        private readonly Lazy<IUserCalendarRepository> _lazyUserCalendarRepository;
        public RepositoryManager(RepositoryDbContext dbContext)
        {
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
            _lazyJobRepository = new Lazy<IJobRepository>(() => new JobRepository(dbContext));
            _lazyCompanyRepository = new Lazy<ICompanyRepository>(() => new CompanyRepository(dbContext));
            _lazySkillsRepository = new Lazy<ISkillsRepository>(() => new SkillsRepository(dbContext));
            _lazyJobsSkillsRepository = new Lazy<IJobSkillsRepository>(() => new JobSkillsRepository(dbContext));
            _lazyJobsCategoryRepository = new Lazy<IJobCategoryRepository>(() => new JobCategoryRepository(dbContext));
            _lazyApplicationRepository = new Lazy<IApplicationRepository>(() => new ApplicationRepository(dbContext));
            _lazyEmployeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(dbContext));
            _lazyJobLocationRepository = new Lazy<IJobLocationRepository>(() => new JobLocationRepository(dbContext));
            _lazyApplicationCommentsRepository = new Lazy<IApplicationCommentsRepository>(() => new ApplicationCommentsRepository(dbContext));
            _lazyEmployeeJobRepository = new Lazy<IEmployeeJobRepository>(() => new EmployeeJobRepository(dbContext));
            _lazyUserCalendarRepository = new Lazy<IUserCalendarRepository>(() => new UserCalendarRepository(dbContext));
        }
        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
        public IJobRepository JobsRepository => _lazyJobRepository.Value;
        public ICompanyRepository CompanyRepository => _lazyCompanyRepository.Value;
        public ISkillsRepository SkillsRepository => _lazySkillsRepository.Value;
        public IJobSkillsRepository JobsSkillsRepository => _lazyJobsSkillsRepository.Value;
        public IJobCategoryRepository JobsCategoryRepository => _lazyJobsCategoryRepository.Value;
        public IApplicationRepository ApplicationRepository => _lazyApplicationRepository.Value;
        public IApplicationCommentsRepository ApplicationCommentsRepository => _lazyApplicationCommentsRepository.Value;
        public IEmployeeRepository EmployeeRepository => _lazyEmployeeRepository.Value;
        public IEmployeeJobRepository EmployeeJobRepository => _lazyEmployeeJobRepository.Value;
        public IJobLocationRepository JobLocationRepository => _lazyJobLocationRepository.Value;
        public IUserCalendarRepository UserCalendarRepository => _lazyUserCalendarRepository.Value;
    }
}
