using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.ObjectModel;
using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.ViewModels
{
    public class CandidateApplicationViewModel:BaseViewModel
    {

        private ObservableCollection<User> _candidates = new();
        public string? searchString { get; set; }
        public bool addDisabled { get; set; }

        [CascadingParameter] MudDialogInstance? MudDialog { get; set; }
        [Parameter] public Job? SelectedJob { get; set; }

        [Parameter] public Color Color { get; set; }

        public HashSet<User>? SelectedCandidates { get; set; } = new HashSet<User>();
        public string SearchString { get; set; }

        public void Submit() => MudDialog!.Close(DialogResult.Ok(SelectedCandidates));
        public void Cancel() => MudDialog!.Cancel();
        protected override async Task OnInitializedAsync()
        {

            PropertyChanged += async (sender, e) =>
            {
                await InvokeAsync(() =>
                {
                    StateHasChanged();
                });

            };
            await GetAllCandidates();
         

        }
        public async Task GetAllCandidates()
        {
            var candidates = await ServiceManager!.UserService.GetAvailableCandidatesForApplication(SelectedJob!.Id);
            if (candidates.Any())
            {
                _candidates = new ObservableCollection<User>(candidates);
            }
            else
            {
                addDisabled = true;
            }
               

        }
        public bool FilterFunc1(User element) => FilterFunc(element, SearchString);
        

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
        public void NavigateToCreateCandidatePage()
        {
            NavigationManager!.NavigateTo("/candidate/create", false);
        }

        public ObservableCollection<User> Candidates
        {
            get { return _candidates; }
            set { SetValue(ref _candidates, value); }
        }
    }
}
