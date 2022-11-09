using MudBlazor;
using System.Collections.ObjectModel;
using LinkBuildingTool.Components.Dialogs;
using LinkBuildingTool.Core.Domain.Entities;
using LinkBuildingTool.Helpers;

namespace LinkBuildingTool.ViewModels
{
    public class AgentViewModel:BaseViewModel
    {
        private ObservableCollection<User> _agents = new();

        public string? _searchStringAgents;
        public string? _searchStringArchAgents;
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
    

        }

        public void NavigateToCreateAgentPage()
        {
            NavigationManager!.NavigateTo("/agent/create");

        }
        public void NavigateToUpdateAgentPage(string agentId)
        {
            NavigationManager!.NavigateTo("/agent/update/"+agentId);

        }
     
       
        public async Task GetAllAgents()
        {

            try
            {


                var agents = await ServiceManager!.UserService.GetAllAgents();
                if (agents != null) {
                    _agents = new ObservableCollection<User>(agents);
                    StateHasChanged();
                }
                  
            }
            catch(Exception ex)
            {

            }
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
        private  async Task<DialogResult> SetConfirmDialog()
        {
            var settingsDialog = new SettingDialogParameters<ConfirmComponent>(DialogService!, "Confirm", "Are you sure you want to delete this user?", "Delete", Color.Error);

            return await settingsDialog.SetConfirmDialog();

        }
        public async Task UndoDeletedAgent(string userId)
        {
            var dialogResult = await SetAlert();
            if (!dialogResult.Cancelled)
            {
                var res = await ServiceManager!.UserService.UndoDeletedUser(userId);
                if (res)
                {
                    await GetAllDeletedAgents();
                }
            }

        }
        public async Task GetAllDeletedAgents()
        {
            try
            {
                var agents = await ServiceManager!.UserService.GetAllDeletedAgentsAsync();
                if (agents != null)
                {
                    _agents = new ObservableCollection<User>(agents);
                }
                _agents = new ObservableCollection<User>();
                StateHasChanged();
            }
            catch(Exception ex)
            {
                _agents = new ObservableCollection<User>();
                StateHasChanged();
            }


        }
        private async Task<DialogResult> SetAlert()
        {
            var settingsDialog = new SettingDialogParameters<ConfirmComponent>(DialogService!, "Confirm", "Are you sure you want to undo this candidate", "Ok", Color.Warning);

            return await settingsDialog.SetConfirmDialog();

        }

        //Search methods for the Tables
        public bool FilterFunc1(User element) => FilterFunc(element, SearchStringAgents);
        public bool FilterFunc2(User element) => FilterFunc(element, SearchStringArchAgents);
        private bool FilterFunc(User element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;

            if (element.FirstName!.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (element.LastName!.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        }

        public ObservableCollection<User> Agents
        {
            get { return _agents; }
            set { SetValue(ref _agents, value); }
        }
        public String SearchStringAgents
        {
            get { return _searchStringAgents!; }
            set { SetValue(ref _searchStringAgents, value); }
        }
        public String SearchStringArchAgents
        {
            get { return _searchStringArchAgents!; }
            set { SetValue(ref _searchStringArchAgents, value); }
        }


    }

}

