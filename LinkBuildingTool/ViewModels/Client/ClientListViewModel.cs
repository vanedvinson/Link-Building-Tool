using LinkBuildingTool.Components.Dialogs;
using LinkBuildingTool.Core.Domain.Entities;
using LinkBuildingTool.Helpers;
using MudBlazor;
using System.Collections.ObjectModel;

namespace LinkBuildingTool.ViewModels 
{ 
    public class ClientListViewModel : BaseViewModel
    {
        private ObservableCollection<Client> _clients = new();

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
        }

        public async Task GetAllClients()
        {
            var cl = await ServiceManager!.ClientService.GetAllClientsAsync();
            if (cl != null)
                _clients = new ObservableCollection<Client>(cl);
        }
        public async Task DeleteClient(Guid id)
        {
            var dialogResult = await SetConfirmDialog();
            if (!dialogResult.Cancelled)
            {
                var isSuccess = await ServiceManager!.ClientService.DeleteClient(id);
                if (isSuccess)
                {
                    Snackbar!.Add("Successfully deleted", Severity.Success);
                    await GetAllClients();
                }
            }
        }

        private async Task<DialogResult> SetConfirmDialog()
        {
            var settingsDialog = new SettingDialogParameters<ConfirmComponent>(DialogService!, "Confirm", "Do you want to delete this client?", "Delete", Color.Error);

            return await settingsDialog.SetConfirmDialog();

        }


        public void NavigateToCreateClientPage()
        {
            NavigationManager!.NavigateTo("/clients/create", false);
        }
        public void NavigateToUpdateClientPage(Guid id)
        {
            NavigationManager!.NavigateTo("/clients/update/" + id, false);
        }

        public ObservableCollection<Client> Clients
        {
            get { return _clients; }
            set { SetValue(ref _clients, value); }
        }
    }
}
