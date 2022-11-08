using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.ObjectModel;
using SystemDuo.Components.Dialogs;
using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Persistence;
using SystemDuo.Helpers;

namespace SystemDuo.ViewModels
{
    public class CandidateViewModel:BaseViewModel
    {    
        private ObservableCollection<User> _candidates = new();
        private ObservableCollection<Category> _categories = new();
        private Category? _category = new();
        private string? _searchStringCandidates;
        private string? _searchStringCandidate;
        private string? _searchStringEmployees;
        private string? _searchStringEmployed;
        private string? _searchStringArchived;
        private bool _longTerm;
        private bool _shortTerm;

        protected override async Task OnInitializedAsync()
        {

            PropertyChanged += async (sender, e) =>
            {
                await InvokeAsync(() =>
                {
                    StateHasChanged();
                });

            };

           //Load first unemployeed
            await GetAllCandidates(false);
            await GetAllCategories();

        }
   
        public async Task DeleteCandidate(string candidateId,bool employeed)
        {
            var dialogResult = await SetConfirmDialog();
            if (!dialogResult.Cancelled)
            {
                var isSuccess = await ServiceManager!.UserService.DeleteUser(candidateId);
                if (isSuccess)
                {
                    await GetAllCandidates(employeed);
                }
            }
        }
        private async Task<DialogResult> SetConfirmDialog()
        {
            var settingsDialog = new SettingDialogParameters<ConfirmComponent>(DialogService!, "Confirm", "Are you sure you want to delete this user?", "Delete", Color.Error);

            
            return await settingsDialog.SetConfirmDialog();

        }
      
        public async Task GetAllCandidates(bool employeed)
        {
            
            var candidates = await ServiceManager!.UserService.GetCandidatesAsync(employeed);
            if (candidates != null)
            {
                Candidates = new ObservableCollection<User>(candidates);
            
            }
                

        }
        public async Task GetAllDeletedCandidates()
        {
            var candidates = await ServiceManager!.UserService.GetAllDeletedCandidatesAsync();
            if (candidates != null)
            {
                Candidates = new ObservableCollection<User>(candidates);
            }


        }
        public async Task UndoDeletedCandidate(string userId)
        {
            var dialogResult = await SetAlert();
            if (!dialogResult.Cancelled)
            {
                var res = await ServiceManager!.UserService.UndoDeletedUser(userId);
                if (res)
                {
                   await GetAllDeletedCandidates();
                }
            }
          
        }
        private async Task<DialogResult> SetAlert()
        {
            var settingsDialog = new SettingDialogParameters<ConfirmComponent>(DialogService!, "Confirm", "Are you sure you want to undo this candidate", "Ok", Color.Warning);

            return await settingsDialog.SetConfirmDialog();

        }
        public async Task ShowEmployeeJobDetails(string userId)
        {
            User tmpUser = Candidates.First(f => f.Id == userId);
            tmpUser.EmployeeJob = new ObservableCollection<EmployeeJob>(await ServiceManager!.EmployeeService.GetEmployeeJobAsync(userId));
            tmpUser.ShowDetails = !tmpUser.ShowDetails;
        }
        public async Task EndEmployeeJob(EmployeeJob empJob)
        {
            var res = await ServiceManager!.EmployeeService.EndEmployeeJob(empJob);
            if (res)
            {
                //add success message
            }
        }
        //public async Task GetAllEmployeedCandidates()
        //{
        //    var candidates = await ServiceManager!.UserService.GetEmployeeCandidates();
        //    if (candidates != null)
        //        _candidates = new ObservableCollection<User>(candidates);

        //}
        public async Task GetAllCategories()
        {
            var categories = await ServiceManager!.JobCategoryService.GetAllCategoriesAsync();
            if (categories != null)
            {
                Categories = new ObservableCollection<Category>(categories);
            }
        }
        public async Task GetCandidatesByCategory(Category cat)
        {
            var candidates = await ServiceManager!.UserService.GetCandidatesByCategoryAsync(cat);
            if (candidates != null)
            {
                Candidates = new ObservableCollection<User>(candidates);
            }
        }
        public async Task GetCandidatesByCatetoryAndTerm()
        {
            var candidates = await ServiceManager!.UserService.GetCandidatesByTermAsync(Category, LongTerm, ShortTerm);
            if (candidates != null)
            {
                Candidates = new ObservableCollection<User>(candidates);
            }
        }
        public async void FilterCandidatesByCategory()
        {
            if (Category!.Name != "Show All")
                await GetCandidatesByCategory(Category);
            else
                await GetAllCandidates(false);
        }
        public async void FilterCandidatesByTerms()
        {
            //if (Category!.Name != "Show All")
                await GetCandidatesByCatetoryAndTerm();
            //await GetCandidatesByCategory(Category);
            //else
                //await GetAllCandidates(false);
                //await GetAllCandidates(false);
        }
        public void NavigateToCreateCandidatePage()
        {
            NavigationManager!.NavigateTo("/candidate/create", false);
        }
        public void NavigateToUpdateCandidatePage(string candidateId)
        {
            NavigationManager!.NavigateTo("/candidate/update/" + candidateId, false);
        }

        //Methods Search for the Table
        public bool FilterFunc1(User element) => FilterFunc(element, SearchStringCandidates);
        public bool FilterFunc2(EmployeeJob element) => FilterFuncJob(element, SearchStringCandidate);
        public bool FilterFunc3(User element) => FilterFunc(element, SearchStringEmployees);
        public bool FilterFunc4(EmployeeJob element) => FilterFuncJob(element, SearchStringEmployed);
        public bool FilterFunc5(User element) => FilterFunc(element, SearchStringArchived);

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
        private bool FilterFuncJob(EmployeeJob element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;

            if (element.User.FirstName!.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        }

        public ObservableCollection<User> Candidates
        {
            get { return _candidates; }
            set { SetValue(ref _candidates, value); }
        }
        public ObservableCollection<Category> Categories
        {
            get { return _categories; }
            set { SetValue(ref _categories, value); }
        }

        public Category Category
        {
            get { return _category!; }
            set
            {
                SetValue(ref _category, value);
                _longTerm = false;
                _shortTerm = false;
                FilterCandidatesByCategory();
                //FilterCandidatesByTerms();
            }
        }

        public String SearchStringCandidates
        {
            get { return _searchStringCandidates!; }
            set { SetValue(ref _searchStringCandidates, value); }
        }
        public String SearchStringCandidate
        {
            get { return _searchStringCandidate!; }
            set { SetValue(ref _searchStringCandidate, value); }
        }
        public String SearchStringEmployees
        {
            get { return _searchStringEmployees!; }
            set { SetValue(ref _searchStringEmployees, value); }
        }
        public String SearchStringEmployed
        {
            get { return _searchStringEmployed!; }
            set { SetValue(ref _searchStringEmployed, value); }
        }
        public String SearchStringArchived
        {
            get { return _searchStringArchived!; }
            set { SetValue(ref _searchStringArchived, value); }
        }


        public bool LongTerm
        {
            get { return _longTerm!; }
            set 
            { 
                SetValue(ref _longTerm, value); 
                FilterCandidatesByTerms(); 
            }
        }
        public bool ShortTerm
        {
            get { return _shortTerm!; }
            set 
            { 
                SetValue(ref _shortTerm, value); 
                FilterCandidatesByTerms(); 
            }
        }
    }
}
