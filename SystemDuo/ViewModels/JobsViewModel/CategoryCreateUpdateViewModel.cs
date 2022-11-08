using Microsoft.AspNetCore.Components;
using MudBlazor;
using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.ViewModels
{
    public class CategoryCreateUpdateViewModel:BaseViewModel
    {
        [CascadingParameter] MudDialogInstance? MudDialog { get; set; }
        private Category _category = new();
        public async Task CreateCategory()
        {
            if (Category.Id != Guid.Empty)
            {
                var isUpdated = await ServiceManager!.JobCategoryService.UpdateCategory(Category);
                if (isUpdated)
                {
                    MudDialog!.Close();
                }
            }
            else
            {
                var isCreated = await ServiceManager!.JobCategoryService.CreateCategory(Category);
                if (isCreated)
                {
                    Snackbar!.Add("Successfully created", Severity.Success);
                    MudDialog!.Close();
                }

            }
            //var res = await ServiceManager!.JobCategoryService.CreateCategory(Category);
            //if (res)
            //{

            //    Category = new();
            //    Snackbar!.Add("Successfully created", Severity.Success);

            //    MudDialog!.Close(DialogResult.Ok("Bla"));


            //}
            // NavigationManager!.NavigateTo("/jobs/settings", true);
         
        }
        public void Cancel()
        {
            MudDialog!.Cancel();
        }
        [Parameter]
        public Category Category
        {
            get { return _category; }
            set { SetValue(ref _category, value); }
        }
    }
}
