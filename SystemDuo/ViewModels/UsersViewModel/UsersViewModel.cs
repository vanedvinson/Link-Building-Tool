using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.ObjectModel;
using SystemDuo.Components.Dialogs;
using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Dto;
using SystemDuo.Core.Services.Abstractions;
using SystemDuo.Helpers;
using SystemDuo.ViewModels.Interfaces;

namespace SystemDuo.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {

        private ObservableCollection<User> _agents = new();
        private ObservableCollection<User> _users = new(); 
        public string? searchString { get; set; }
        protected override async Task OnInitializedAsync()
        {

            PropertyChanged += async (sender, e) =>
            {
                await InvokeAsync(() =>
                {
                    StateHasChanged();
                });

            };

            await GetAllAgents();
            await GetAllUsers();

        }

        public void NavigateToNewJob()
        {
            NavigationManager!.NavigateTo("/create/job");

        }
        public async Task DeleteAgent(string agentId)
        {
            var dialogResult = await SetConfirmDialog();
            if (!dialogResult.Cancelled)
            {
                var isSuccess = await ServiceManager!.UserService.DeleteUser(agentId);
                if (isSuccess)
                {
                    await GetAllAgents();
                }
            }
        }
        private async Task<DialogResult> SetConfirmDialog()
        {
            var settingsDialog = new SettingDialogParameters<ConfirmComponent>(DialogService!, "Bestätigen", "Are you sure you want to delete this user?", "Delete", Color.Error);


            return await settingsDialog.SetConfirmDialog();

        }
        public async Task GetAllAgents()
        {
            var agents = await ServiceManager!.UserService.GetByRoleAsync("agent");
            if (agents != null)
                _agents = new ObservableCollection<User>(agents);

        }
        public async Task GetAllUsers()
        {
            var users = await ServiceManager!.UserService.GetByRoleAsync("user");
            if (users != null)
                _users = new ObservableCollection<User>(users);

        }


    

        public ObservableCollection<User> Agents
        {
            get { return _agents; }
            set { SetValue(ref _agents, value); }
        }
        public ObservableCollection<User> Users
        {
            get { return _users; }
            set { SetValue(ref _users, value); }
        }
    }



}
