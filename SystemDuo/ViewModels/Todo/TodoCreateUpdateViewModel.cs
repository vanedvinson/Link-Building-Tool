using SystemDuo.Core.Domain.Entities;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SystemDuo.ViewModels
{
    public class TodoCreateUpdateViewModel : BaseViewModel
    {
        private Todo _todo = new();

        //for selects
        private Status _status = new();
        private ObservableCollection<Status> _statuses = new();

        private LinkAttribute _linkAtt = new();
        private ObservableCollection<LinkAttribute> _linkAtts = new();

        private LinkType _linkType = new();
        private ObservableCollection<LinkType> _linkTypes = new();

        private ClientDomain _clientDomain = new();
        private ObservableCollection<ClientDomain> _clientDomains = new();

        private Client _client = new();
        private ObservableCollection<Client> _clients = new();


        //private ObservableCollection<ClientType> _types = new();
        private Status _selectedStatus = new();
        private LinkAttribute _selectedLinkAtt = new();
        private LinkType _selectedLinkType = new();
        private ClientDomain _selectedDomain = new();
        private Client _selectedClient = new();

        [Parameter] public Guid todoId { get; set; }

        protected override async Task OnInitializedAsync()
        {

            PropertyChanged += async (sender, e) =>
            {
                await InvokeAsync(() =>
                {
                    StateHasChanged();
                });

            };

            await GetAllClients();
            await GetAllDomains();
            await GetAllLinkAttributes();
            await GetAllLinkTypes();
            await GetAllStatuses();

            if (todoId != Guid.Empty)
            {
                await GetTaskByIdAsync(todoId);

                if(Todo != null)
                {
                    SelectedClient = Todo.Client!;
                    SelectedClientDomain = Todo.Domain!;
                    SelectedLinkType = Todo.LinkType!;
                    SelectedLinkAttribute = Todo.LinkAttribute!;
                    SelectedStatus = Todo.Status!;
                }
            }
            else
            {
                //pozovi u kolekcije sve selekcije i dodeli ih kao ispod ovo
                //SelectedType = Types.FirstOrDefault();
                if (Clients != null) 
                    SelectedClient = Clients.FirstOrDefault();
                if (Domains != null)
                    SelectedClientDomain = Domains.FirstOrDefault();
                if (Statuses != null)
                    SelectedStatus = Statuses.Where(x => x.Name == "Vorschlag").FirstOrDefault();
                if (LinkAttributes != null)
                    SelectedLinkAttribute = LinkAttributes.FirstOrDefault();
                if (LinkTypes != null)
                    SelectedLinkType = LinkTypes.FirstOrDefault();

            }

            //await GetAllClientTypes();
            
        }

        public async Task GetTaskByIdAsync(Guid id)
        {
            var res = await ServiceManager!.TodoService.GetTodoByIdAsync(id);
            if (res != null)
            {
                _todo = res;
                StateHasChanged();
            }
        }

        public async Task CreateOrUpdateTodo()
        {
            if (Todo.Id != Guid.Empty)
            {
                Todo.Client = SelectedClient;
                Todo.Domain = SelectedClientDomain;
                Todo.LinkType = SelectedLinkType;
                Todo.LinkAttribute = SelectedLinkAttribute;
                Todo.Status = SelectedStatus;
                var res = await ServiceManager!.TodoService.UpdateTodo(Todo);
                if (res)
                {
                    Snackbar!.Add("Successfully updated", Severity.Success);
                    Todo = new();
                    NavigationManager!.NavigateTo("/dashboard", false);
                }
                else
                {
                    Snackbar!.Add("Unsuccessfully updated", Severity.Error);
                }

            }
            else
            {
                Todo.Client = SelectedClient;
                Todo.Domain = SelectedClientDomain;
                Todo.LinkType = SelectedLinkType;
                Todo.LinkAttribute = SelectedLinkAttribute;
                Todo.Status = SelectedStatus;
                var res = await ServiceManager!.TodoService.CreateTodo(Todo);
                if (res)
                {
                    Snackbar!.Add("Successfully created", Severity.Success);
                    Todo = new();
                    NavigationManager!.NavigateTo("/dashboard", false);
                }
                else
                {
                    Snackbar!.Add("Unsuccessfully created", Severity.Error);
                }
            }
        }

        public async Task GetAllStatuses()
        {
            var st = await ServiceManager!.StatusService.GetAllStatusesAsync();
            if (st != null)
                _statuses = new ObservableCollection<Status>(st);
        }
        public async Task GetAllLinkAttributes()
        {
            var la = await ServiceManager!.LinkAttributeService.GetAllLinkAttributesAsync();
            if (la != null)
                _linkAtts = new ObservableCollection<LinkAttribute>(la);
        }
        public async Task GetAllLinkTypes()
        {
            var lt = await ServiceManager!.LinkTypeService.GetAllLinkTypesAsync();
            if (lt != null)
                _linkTypes = new ObservableCollection<LinkType>(lt);
        }
        public async Task GetAllDomains()
        {
            var dm = await ServiceManager!.DomainService.GetAllDomainsAsync();
            if (dm != null)
                _clientDomains = new ObservableCollection<ClientDomain>(dm);
        }
        public async Task GetAllClients()
        {
            var cl = await ServiceManager!.ClientService.GetAllClientsAsync();
            if (cl != null)
                _clients = new ObservableCollection<Client>(cl);
        }




        public Todo Todo
        {
            get { return _todo; }
            set { SetValue(ref _todo, value); }
        }

        public Status SelectedStatus
        {
            get { return _selectedStatus; }
            set { SetValue(ref _selectedStatus, value); }
        }
        public LinkAttribute SelectedLinkAttribute
        {
            get { return _selectedLinkAtt; }
            set { SetValue(ref _selectedLinkAtt, value); }
        }
        public LinkType SelectedLinkType
        {
            get { return _selectedLinkType; }
            set { SetValue(ref _selectedLinkType, value); }
        }
        public ClientDomain SelectedClientDomain
        {
            get { return _selectedDomain; }
            set { SetValue(ref _selectedDomain, value); }
        }
        public Client SelectedClient
        {
            get { return _selectedClient; }
            set { SetValue(ref _selectedClient, value); }
        }

        public ObservableCollection<Status> Statuses
        {
            get { return _statuses; }
            set { SetValue(ref _statuses, value); }
        }
        public ObservableCollection<Client> Clients
        {
            get { return _clients; }
            set { SetValue(ref _clients, value); }
        }
        public ObservableCollection<ClientDomain> Domains
        {
            get { return _clientDomains; }
            set { SetValue(ref _clientDomains, value); }
        }
        public ObservableCollection<LinkAttribute> LinkAttributes
        {
            get { return _linkAtts; }
            set { SetValue(ref _linkAtts, value); }
        }
        public ObservableCollection<LinkType> LinkTypes
        {
            get { return _linkTypes; }
            set { SetValue(ref _linkTypes, value); }
        }

    }
}
