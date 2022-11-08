using SystemDuo.Components.Dialogs;
using SystemDuo.Core.Domain.Entities;
using SystemDuo.Helpers;
using MudBlazor;
using System.Collections.ObjectModel;

namespace SystemDuo.ViewModels
{
    public class DomainListViewModel : BaseViewModel
    {
        private ObservableCollection<ClientDomain> _domains = new();


        protected override async Task OnInitializedAsync()
        {
            PropertyChanged += async (sender, e) =>
            {
                await InvokeAsync(() =>
                {
                    StateHasChanged();
                });

            };

            await GetAllDomains();
        }


        public async Task GetAllDomains()
        {
            var domain = await ServiceManager!.DomainService.GetAllDomainsAsync();
            if (domain != null)
                _domains = new ObservableCollection<ClientDomain>(domain);
        }

        public async Task DeleteDomain(Guid id)
        {
            var dialogResult = await SetConfirmDialog();
            if (!dialogResult.Cancelled)
            {
                var isSuccess = await ServiceManager!.DomainService.DeleteDomain(id);
                if (isSuccess)
                {
                    Snackbar!.Add("Successfully deleted", Severity.Success);
                    await GetAllDomains();
                }
            }
        }

        private async Task<DialogResult> SetConfirmDialog()
        {
            var settingsDialog = new SettingDialogParameters<ConfirmComponent>(DialogService!, "Confirm", "Do you want to delete this Domain?", "Delete", Color.Error);

            return await settingsDialog.SetConfirmDialog();
        }

        public void NavigateToCreateDomainPage()
        {
            NavigationManager!.NavigateTo("/domain/create", false);
        }
        public void NavigateToUpdateCompanyPage(Guid id)
        {
            NavigationManager!.NavigateTo("/domains/update/" + id, false);
        }

        public ObservableCollection<ClientDomain> Domains
        {
            get { return _domains; }
            set { SetValue(ref _domains, value); }
        }           
    }
}
