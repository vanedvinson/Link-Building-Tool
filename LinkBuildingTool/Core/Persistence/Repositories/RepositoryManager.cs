using LinkBuildingTool.Core.Domain.Repositories;

namespace LinkBuildingTool.Core.Persistence.Repositories
{
    public class RepositoryManager:IRepositoryManager
    {
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;
        private readonly Lazy<ILinkAttributeRepository> _linkAttributeRepository;
        private readonly Lazy<IWebmasterRepository> _webmasterRepository;
        private readonly Lazy<ITodoRepository> _todoRepository;
        private readonly Lazy<IDomainRepository> _domainRepository;
        private readonly Lazy<IClientRepository> _clientRepository;
        private readonly Lazy<IClientTypeRepository> _clientTypeRepository;
        private readonly Lazy<IStatusRepository> _statusRepository;
        private readonly Lazy<ILinkTypeRepository> _linkTypeRepository;
        public RepositoryManager(RepositoryDbContext dbContext)
        {
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
            _linkAttributeRepository = new Lazy<ILinkAttributeRepository>(() => new LinkAttributeRepository(dbContext));
            _webmasterRepository = new Lazy<IWebmasterRepository>(() => new WebmasterRepository(dbContext));
            _todoRepository = new Lazy<ITodoRepository>(() => new TodoRepository(dbContext));
            _domainRepository = new Lazy<IDomainRepository>(() => new DomainRepository(dbContext));
            _clientRepository = new Lazy<IClientRepository>(() => new ClientRepository(dbContext));
            _clientTypeRepository = new Lazy<IClientTypeRepository>(() => new ClientTypeRepository(dbContext));
            _statusRepository = new Lazy<IStatusRepository>(() => new StatusRepository(dbContext));
            _linkTypeRepository = new Lazy<ILinkTypeRepository>(() => new LinkTypeRepository(dbContext));
        }
        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
        public ILinkAttributeRepository LinkAttributeRepository => _linkAttributeRepository.Value;
        public IWebmasterRepository WebmasterRepository => _webmasterRepository.Value;
        public ITodoRepository TodoRepository => _todoRepository.Value;
        public IDomainRepository DomainRepository => _domainRepository.Value;
        public IClientRepository ClientRepository => _clientRepository.Value;
        public IClientTypeRepository ClientTypeRepository => _clientTypeRepository.Value;
        public IStatusRepository StatusRepository => _statusRepository.Value;
        public ILinkTypeRepository LinkTypeRepository => _linkTypeRepository.Value;
    }
}
