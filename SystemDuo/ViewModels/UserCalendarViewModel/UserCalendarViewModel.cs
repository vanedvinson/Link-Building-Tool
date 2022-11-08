using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using System.Collections.ObjectModel;
using SystemDuo.Components.Dialogs;
using SystemDuo.Core.Domain.Entities;
using SystemDuo.Helpers;

namespace SystemDuo.ViewModels
{
    public class UserCalendarViewModel : BaseViewModel
    {
        private ObservableCollection<UserCalendar> _userCalendars = new();
        private UserCalendar _userCalendar = new();
        public TimeSpan? time { get; set; }

        public string? _searchStringCalendar;
        protected override async Task OnInitializedAsync()
        {

            PropertyChanged += async (sender, e) =>
            {
                await InvokeAsync(() =>
                {
                    StateHasChanged();
                });

            };


            UserCalendar.User = new();
            authState = await authProvider!.GetAuthenticationStateAsync();
            await GetAllUserCalendars();

        }

        [Inject]
        TokenAuthenticationStateProvider? authProvider { get; set; }
        private AuthenticationState? authState;
        public async Task GetAllUserCalendars()
        {

            var loggedUserEmail = authState!.User.Identity!.Name;
            var userCalendars = await ServiceManager!.UserCalendarService.GetAllUserCalendarAsync(loggedUserEmail);
            if (userCalendars != null)
                _userCalendars = new ObservableCollection<UserCalendar>(userCalendars);
        }

        public async Task CreateUserCalendar()
        {


            UserCalendar.User!.Email = authState!.User.Identity!.Name;
            bool res;
            if (UserCalendar.Id == Guid.Empty)
            {
                res = await ServiceManager!.UserCalendarService.CreateUserCalendar(UserCalendar);
            }
            else
            {
                res = await ServiceManager!.UserCalendarService.UpdateUserCalendar(UserCalendar);
            }
            if (res)
            {
                UserCalendar = new();
                UserCalendar.User = new();
                await GetAllUserCalendars();
            }
        }
        public void EditUserCalendar(UserCalendar userCalendar)
        {
            UserCalendar = userCalendar;
        }
        public async Task DeleteUserCalendar(UserCalendar userCalendar)
        {
            var dialogResult = await SetConfirmDialog();
            if (!dialogResult.Cancelled)
            {
                var isSuccess = await ServiceManager!.UserCalendarService.DeleteUserCalendar(userCalendar);
                if (isSuccess)
                {
                    await GetAllUserCalendars();
                }
            }
        }

        private async Task<DialogResult> SetConfirmDialog()
        {
            var settingsDialog = new SettingDialogParameters<ConfirmComponent>(DialogService!, "Confirm", "Do you want to delete this appointment?", "Delete", Color.Error);

            return await settingsDialog.SetConfirmDialog();

        }

        public void NavigateToCreateCompanyPage()
        {
            NavigationManager!.NavigateTo("/company/create", false);
        }
        public void NavigateToUpdateCompanyPage(Guid companyId)
        {
            NavigationManager!.NavigateTo("/company/update/" + companyId, false);
        }



        public ObservableCollection<UserCalendar> UserCalendars
        {
            get { return _userCalendars; }
            set { SetValue(ref _userCalendars, value); }
        }
        public UserCalendar UserCalendar
        {
            get => _userCalendar;
            set { SetValue(ref _userCalendar, value); }
        }
        public bool IsDisabled
        {
            get
            {
                if (_userCalendar.Date == null)
                    return true;
                if (string.IsNullOrEmpty(_userCalendar.Note))
                    return true;
                return false;

            }
        }
    }
}
