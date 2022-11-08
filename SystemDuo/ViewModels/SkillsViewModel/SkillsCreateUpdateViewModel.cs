using Microsoft.AspNetCore.Components;
using MudBlazor;
using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.ViewModels
{
    public class SkillsCreateUpdateViewModel:BaseViewModel
    {
        private Skills _skills = new();
        [CascadingParameter] MudDialogInstance? MudDialog { get; set; }
        public async Task CreateSkill()
        {

            if (Skills.Id != Guid.Empty)
            {
                var isUpdated = await ServiceManager!.SkillService.UpdateSkill(Skills);
                if (isUpdated)
                {
                    MudDialog!.Close();
                }
            }
            else
            {
                var isCreated = await ServiceManager!.SkillService.CreateSkill(Skills);
                if (isCreated)
                {
                    Snackbar!.Add("Successfully created", Severity.Success);
                    MudDialog!.Close();
                }

            }
            
        }
        public void Cancel()
        {
            MudDialog!.Cancel();
        }
        [Parameter]
        public Skills Skills
        {
            get { return _skills; }
            set { SetValue(ref _skills, value); }
        }
    }
}
