
using SystemDuo.Core.Domain.Entities;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.ObjectModel;

namespace SystemDuo.ViewModels
{
    public class ClientCreateUpdateViewModel : BaseViewModel
    {
        private Client _client = new();
        private ClientType _type = new();
        private ObservableCollection<ClientType> _types = new();
        private ClientType _selectedType = new();

        //parameter is set when update is selected
        [Parameter] public Guid clientId { get; set; }

        protected override async Task OnInitializedAsync()
        {

            PropertyChanged += async (sender, e) =>
            {
                await InvokeAsync(() =>
                {
                    StateHasChanged();
                });

            };

            if (clientId != Guid.Empty)
            {
                await GetClientByIdAsync(clientId);
                SelectedType = Client.Type!;
            }
            else
            {
                SelectedType = Types.FirstOrDefault();
            }

            await GetAllClientTypes();

        }

        public async Task GetClientByIdAsync(Guid id)
        {
            var res = await ServiceManager!.ClientService.GetClientByIdAsync(id);
            if (res != null)
            {
                _client = res;
                StateHasChanged();
            }
        }


        public async Task CreateOrUpdateClient()
        {
            if (Client.Id != Guid.Empty)
            {
                //Webmaster.CategoryId = SelectedJobCategory.Id;
                Client.Type = SelectedType;
                var res = await ServiceManager!.ClientService.UpdateClient(Client);
                if (res)
                {
                    //TODO Add snackbar for success update
                    Snackbar!.Add("Successfully updated", Severity.Success);
                    Client = new();
                    NavigationManager!.NavigateTo("/clients", false);
                }

            }
            else
            {
                Client.Type = SelectedType;
                var res = await ServiceManager!.ClientService.CreateClient(Client);
                if (res)
                {
                    //TODO Add snackbar for success create
                    Snackbar!.Add("Successfully created", Severity.Success);
                    Client = new();
                    NavigationManager!.NavigateTo("/clients", false);
                }
            }




            // return res;
        }

        public async Task ChangeSwitch()
        {

        }

        public async Task GetAllClientTypes()
        {
            var ct = await ServiceManager!.ClientTypeService.GetAllClientTypesAsync();
            if (ct != null)
                _types = new ObservableCollection<ClientType>(ct);
        }


        public Client Client
        {
            get { return _client; }
            set { SetValue(ref _client, value); }
        }
        public ClientType Type
        {
            get { return _type; }
            set { SetValue(ref _type, value); }
        }
        public ObservableCollection<ClientType> Types
        {
            get { return _types; }
            set { SetValue(ref _types, value); }
        }
        public ClientType SelectedType
        {
            get { return _selectedType; }
            set { SetValue(ref _selectedType, value); }
        }
    }
}
