using SystemDuo.Components.Dialogs;
using SystemDuo.Core.Domain.Entities;
using SystemDuo.Helpers;
using MudBlazor;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;

namespace SystemDuo.ViewModels
{
    public class WebmasterListViewModel : BaseViewModel
    {
        private ObservableCollection<Webmaster> _webmasters = new();

        protected override async Task OnInitializedAsync()
        {
            PropertyChanged += async (sender, e) =>
            {
                await InvokeAsync(() =>
                {
                    StateHasChanged();
                });

            };

            await GetAllWebmasters();
        }

        public async Task GetAllWebmasters()
        {
            var wm = await ServiceManager!.WebmasterService.GetAllWebmastersAsync();
            if (wm != null)
                _webmasters = new ObservableCollection<Webmaster>(wm);
        }
        public async Task DeleteWebmaster(Guid id)
        {
            var dialogResult = await SetConfirmDialog();
            if (!dialogResult.Cancelled)
            {
            var isSuccess = await ServiceManager!.WebmasterService.DeleteWebmaster(id);
            if (isSuccess)
            {
                Snackbar!.Add("Successfully deleted", Severity.Success);
                await GetAllWebmasters();
            }
            }
        }

        private async Task<DialogResult> SetConfirmDialog()
        {
            var settingsDialog = new SettingDialogParameters<ConfirmComponent>(DialogService!, "Confirm", "Do you want to delete this webmaster?", "Delete", Color.Error);

            return await settingsDialog.SetConfirmDialog();

        }


        public void NavigateToCreateCompanyPage()
        {
            NavigationManager!.NavigateTo("/webmasters/create", false);
        }
        public void NavigateToUpdateCompanyPage(Guid id)
        {
            NavigationManager!.NavigateTo("/webmasters/update/" + id, false);
        }

        public ObservableCollection<Webmaster> Webmasters
        {
            get { return _webmasters; }
            set { SetValue(ref _webmasters, value);}
        }
    }
}
