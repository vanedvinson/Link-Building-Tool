using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.ObjectModel;
using SystemDuo.Components.Dialogs;
using SystemDuo.Components.SkillComponent;
using SystemDuo.Core.Domain.Entities;


namespace SystemDuo.ViewModels
{
    public class SkillsViewModel : BaseViewModel
    {
        private ObservableCollection<Skills> _skills = new();

        public string? _searchStringSkills;

        protected override async Task OnInitializedAsync()
        {

            PropertyChanged += async (sender, e) =>
            {
                await InvokeAsync(() =>
                {
                    StateHasChanged();
                });

            };

            await GetAllSkills();

        }

       
   
          public async Task OpenUpdateSkillDialog(Skills skills)
        {
            var parameter = new DialogParameters();
            parameter.Add("Skills", skills);

            var dialog = DialogService!.Show<SkillFormComponent>("Edit skills", parameter);

            var res = await dialog.Result;
            if (!res.Cancelled)
            {
                await GetAllSkills();


            }
        }
       
        public async Task OpenCreateSkillDialog()
        {

            var dialog = DialogService!.Show<SkillFormComponent>("Create skill ");

            var result = await dialog.Result;

            if (!result.Cancelled)
            {
              
                await GetAllSkills();
                StateHasChanged();
                //   NavigationManager!.NavigateTo("/jobssettings", true);



            }

        }
       
        public async Task DeleteSkill(Skills skill)
        {
            var parameters = new DialogParameters();
            parameters.Add("ContentText", "Do you really want to delete these records? This process cannot be undone.");
            parameters.Add("ButtonText", "Delete");
            parameters.Add("Color", Color.Error);

            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };

            var dialog = DialogService!.Show<ConfirmComponent>("Delete", parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
               
                var isSuccess = await ServiceManager!.SkillService.DeleteSkill(skill);
                if (isSuccess)
                {
                   // _newSkill = new();
                    Snackbar!.Add($"Success deleted skill", Severity.Success);
                    
                    
                    await GetAllSkills();
                }
            }

        }
        public async Task GetAllSkills()
        {
            var skills = await ServiceManager!.SkillService.GetAllSkillsAsync();
            if (skills != null)
                Skills = new ObservableCollection<Skills>(skills);

        }

        //Table search Methods
        public bool FilterFunc1(Skills element) => FilterFunc(element, SearchStringSkills);
        private bool FilterFunc(Skills element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;

            if (element.Name!.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        }

        public ObservableCollection<Skills> Skills
        {
            get { return _skills; }
            set { SetValue(ref _skills, value); }
        }

        public String SearchStringSkills
        {
            get { return _searchStringSkills!; }
            set { SetValue(ref _searchStringSkills, value); }
        }

    }

}
