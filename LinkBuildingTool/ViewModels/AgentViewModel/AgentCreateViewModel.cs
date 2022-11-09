using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;
using LinkBuildingTool.Core.Domain.Entities;
using LinkBuildingTool.Core.Dto;
using static LinkBuildingTool.Helpers.GenerateRandomPassword;
namespace LinkBuildingTool.ViewModels
{
    public class AgentCreateViewModel : BaseViewModel
    {
        private UserForCreationOrUpdate _agent = new();
        private ObservableCollection<Role> _roles = new();
        private IEnumerable<string> _selectedRoles = new List<string>();
        //parameter is set when update is selected
        [Parameter] public string agentId { get; set; }
        public string ButtonText { get; set; } = "Create";
        protected override async Task OnInitializedAsync()
        {

            PropertyChanged += async (sender, e) =>
            {
                await InvokeAsync(() =>
                {
                    StateHasChanged();
                });

            };
            await GetRoles("intern");
            if (agentId != null)
            {
                await GetAgentByIdAsync(agentId);
                ButtonText = "Save";
            }



        }
        public async Task GetAgentByIdAsync(string agentId)
        {
            var res = await ServiceManager!.UserService.GetUserByIdAsync(agentId);
            if (res != null)
            {
                _agent.Id = res.Id;
                _agent.FirstName = res.FirstName;
                _agent.MobileNumber = res.MobileNumber;
                _agent.LastName = res.LastName;
                _agent.Email = res.Email;
                _agent.City = res.City;
                _agent.Country = res.Country;
                _agent.Address = res.Address;
                _agent.PostalCode = res.PostalCode;
                //   _agent.RoleName = (IEnumerable<string>?)res.Roles;
                foreach (var r in res.UserRoles1!)
                {
                    var toAdd = Roles.Where(x => x.Name!.Equals(r)).FirstOrDefault();
                    List<string> list = _selectedRoles.ToList();

                    //Add new item to list.
                    list.Add(toAdd.Name);

                    //Cast list to IEnumerable
                    _selectedRoles = (IEnumerable<string>)list;
                }
            }
            
        }
        public string state = "Message box hasn't been opened yet";
        public async Task CreateOrUpdateAgent()
        {
            bool res = false;

            if (SelectedRoles.Count()==0)
            {
                bool? result = await DialogService!.ShowMessageBox(
                  "Warning",
                  "Select Roles!",
                  yesText: "Ok!", cancelText: "Cancel");
                state = result == null ? "Cancelled" : "Ok!";
                StateHasChanged();
                return;
            }
            if (Agent.Id != null)
            {
                Agent.RoleName = SelectedRoles;
                res = await ServiceManager!.UserService.UpdateUser(Agent);
            }
                
            else
            {
                Agent.RoleName = SelectedRoles;
                Agent.Password = GeneratePassword(8,1,1);
              
                res = await ServiceManager!.UserService.CreateUser(Agent);
            }

            if (res)
            {
                //TODO Add snackbar for success create
                Agent = new();
                NavigationManager!.NavigateTo("/agents", false);
            }

     
        }
        public async Task GetRoles(string type)
        {
            try
            {
                //Account.AccountRole = new AccountRoles();
                var res = await ServiceManager!.UserService.GetRoleByType(type);
                if (res != null)
                    _roles = new ObservableCollection<Role>(res);

            }
            catch (HttpRequestException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        public UserForCreationOrUpdate Agent
        {
            get { return _agent; }
            set { SetValue(ref _agent, value); }
        }
        public ObservableCollection<Role> Roles
        {
            get { return _roles; }
            set { SetValue(ref _roles, value); }
        }
        public IEnumerable<string> SelectedRoles
        {
            get { return _selectedRoles; }
            set { SetValue(ref _selectedRoles, value); }
        }
    }
}
