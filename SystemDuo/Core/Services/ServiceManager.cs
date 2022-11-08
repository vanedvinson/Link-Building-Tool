using Microsoft.AspNetCore.Identity;
using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Domain.Repositories;
using SystemDuo.Core.Services.Abstractions;

namespace SystemDuo.Core.Services
{
    public class ServiceManager:IServiceManager
    {
        private readonly Lazy<IUserService> _lazyUserService;

        private readonly Lazy<ILinkAttributeService> _linkAttributeService;
        private readonly Lazy<IWebmasterService> _webmasterService;
        private readonly Lazy<ITodoService> _todoService;
        private readonly Lazy<IDomainService> _domain;
        private readonly Lazy<IClientService> _client;
        private readonly Lazy<IClientTypeService> _clientType;
        private readonly Lazy<IStatusService> _status;
        private readonly Lazy<ILinkTypeService> _linkTypeService;

        public ServiceManager(IRepositoryManager repositoryManager,UserManager<User> userManager,IMailService mailService,RoleManager<Role> roleManager,ITokenService tokenService)
        {
            _lazyUserService = new Lazy<IUserService>(() => new UserService(userManager, mailService, tokenService,roleManager, repositoryManager));

            _linkAttributeService = new Lazy<ILinkAttributeService>(() => new LinkAttributeService(repositoryManager));
            _webmasterService = new Lazy<IWebmasterService>(() => new WebmasterService(repositoryManager));
            _todoService = new Lazy<ITodoService>(() => new TodoService(repositoryManager));
            _domain = new Lazy<IDomainService>(() => new DomainService(repositoryManager));
            _client = new Lazy<IClientService>(() => new ClientService(repositoryManager));
            _clientType = new Lazy<IClientTypeService>(() => new ClientTypeService(repositoryManager));
            _status = new Lazy<IStatusService>(() => new StatusService(repositoryManager));
            _linkTypeService = new Lazy<ILinkTypeService>(() => new LinkTypeService(repositoryManager));
        }
        public IUserService UserService => _lazyUserService.Value;

        public ILinkAttributeService LinkAttributeService => _linkAttributeService.Value;
        public IWebmasterService WebmasterService => _webmasterService.Value;
        public ITodoService TodoService => _todoService.Value;
        public IDomainService DomainService => _domain.Value;
        public IClientService ClientService => _client.Value;
        public IClientTypeService ClientTypeService => _clientType.Value;
        public IStatusService StatusService => _status.Value;
        public ILinkTypeService LinkTypeService => _linkTypeService.Value;
    }
}
