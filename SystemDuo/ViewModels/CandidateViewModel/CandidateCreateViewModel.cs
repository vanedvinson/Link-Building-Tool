using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;
using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Dto;
using static SystemDuo.Helpers.GenerateRandomPassword;
namespace SystemDuo.ViewModels
{
    public class CandidateCreateViewModel:BaseViewModel
    {
        private UserForCreationOrUpdate _candidate = new();

        private IEnumerable<string> _selectedLanguages = new List<string>();
        private ObservableCollection<Category> _categories = new();
        //parameter is set when update is selected
        [Parameter] public string candidateId { get; set; }
        private Category _selectedCategory = new();
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

           await GetAllCategories();
            //if (candidateId != null)
            //{
            //    await GetCandidateById(candidateId);
            //    ButtonText = "Save";
            //}

            if (candidateId != null)
            {
                await GetCandidateById(candidateId);
                ButtonText = "Save";
            }
        }

        //protected override async Task OnAfterRenderAsync(bool firstRender)
        //{
        //    if (firstRender)
        //    {
        //        if (candidateId != null)
        //        {
        //            await GetCandidateById(candidateId);
        //            ButtonText = "Save";
        //        }
        //    }
        //}

        public async Task GetCandidateById(string candidateId)
        {
            var res = await ServiceManager!.UserService.GetUserByIdAsync(candidateId);
            if (res != null)
            {
                _candidate.Id = res.Id;
                _candidate.FirstName = res.FirstName;
                _candidate.MobileNumber = res.MobileNumber;
                _candidate.LastName = res.LastName;
                _candidate.Email = res.Email;
                _candidate.City = res.City;
                _candidate.Country = res.Country;
                _candidate.Address = res.Address;
                _candidate.PostalCode = res.PostalCode;
                _candidate.Education = res.Education;
                _candidate.Language = res.Language;
                _candidate.LongTerm = res.LongTerm;
                _candidate.ShortTerm = res.ShortTerm;
                if(res.DateOfBirth!=null)
                    
                        _candidate.DateOfBirth = res.DateOfBirth!.Value.ToLocalTime();
                _candidate.Notes = res.Notes;
                SelectedCategory = res.Category;

                try
                {
                    if (_candidate.Language != null)
                    {
                        string[] languages = _candidate.Language!.Split(',');
                        var list = new List<string>();

                        foreach (string language in languages)
                        {
                            if (language != String.Empty)
                            {
                                list.Add(language);
                            }
                           
                         
                          // SelectedLanguages.Add()
                        }
                        SelectedLanguages = new List<string>(list);
                    }
                  
                }
                catch (Exception ex)
                {

                }
               
            }
        }
        public async Task GetAllCategories()
        {
            var categories = await ServiceManager!.JobCategoryService.GetAllCategoriesAsync();
            if (categories != null)
                _categories = new ObservableCollection<Category>(categories);
        }
        public string state = "Message box hasn't been opened yet";
        public async Task CreateOrUpdateCandidate()
        {
            bool res = false;
            if (SelectedCategory.Id==Guid.Empty)
            {
                bool? result = await DialogService!.ShowMessageBox(
                  "Warning",
                  "Select Category!",
                  yesText: "Ok!", cancelText: "Cancel");
                state = result == null ? "Cancelled" : "Ok!";
                StateHasChanged();
                return;
            }
            // 
            if (Candidate.Id != null)
            {
                _candidate.Language = "";
                _candidate.CategoryId=SelectedCategory.Id;
                SetLanguge();
                res = await ServiceManager!.UserService.UpdateUser(Candidate);
            }
               
            else
            {
                SetLanguge();
                _candidate.CategoryId = SelectedCategory.Id;
                _candidate.Password = GeneratePassword(8, 1, 1);
                var list = new List<string>();
                list.Add("Candidate");
                var en = (IEnumerable<string>)list;
                _candidate.RoleName = en;

                res = await ServiceManager!.UserService.CreateUser(Candidate);
            }

            if (res)
            {
                //TODO Add snackbar for success create
                Candidate = new();
                NavigationManager!.NavigateTo("/candidates", false);
            }


        }
        public void SetLanguge()
        {
            if (SelectedLanguages.Count() == 1)
            {
                Candidate.Language = SelectedLanguages.First().ToString();
            }
            else
            {
                foreach (var lang in SelectedLanguages)
                {
                    _candidate.Language = lang + "," + _candidate.Language;
                }

            }
        }
        public UserForCreationOrUpdate Candidate
        {
            get { return _candidate; }
            set { SetValue(ref _candidate, value); }
        }
        public IEnumerable<string> SelectedLanguages
        {
            get { return _selectedLanguages; }
            set { SetValue(ref _selectedLanguages, value); }
        }
        public ObservableCollection<Category> Categories
        {
            get { return _categories; }
            set { SetValue(ref _categories, value); }
        }
        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set { SetValue(ref _selectedCategory, value); }
        }
    }
}
