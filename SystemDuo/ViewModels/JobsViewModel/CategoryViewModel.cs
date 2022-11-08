using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.ObjectModel;
using SystemDuo.Components.Dialogs;
using SystemDuo.Components.CategoryComponent;
using SystemDuo.Core.Domain.Entities;


namespace SystemDuo.ViewModels
{
    public class CategoryViewModel:BaseViewModel
    {
        private ObservableCollection<Category> _categories = new();

        public string? _searchStringCategories;
       
        protected override async Task OnInitializedAsync()
        {

            PropertyChanged += async (sender, e) =>
            {
                await InvokeAsync(() =>
                {
                    StateHasChanged();
                });

            };

            await GetAllJobsCategories();

        }

       
     
        public async Task OpenCreateCategoryDialog()
        {
            
            var dialog = DialogService!.Show<CategoryFormComponent>("Create category ");

            var result = await dialog.Result;

            if (!result.Cancelled)
            {
               
                //NavigationManager!.NavigateTo("/jobssettings", true);

                await GetAllJobsCategories();

            }
            
        }
        public async Task OpenUpdateCategoryDialog(Category category)
        {
            var parameter = new DialogParameters();
            parameter.Add("Category", category);

            var dialog = DialogService!.Show<CategoryFormComponent>("Edit category", parameter);

            var res = await dialog.Result;
            if (!res.Cancelled)
            {
                await GetAllJobsCategories();


            }
        }

        public async Task DeleteCategory(Guid categoryId)
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
                var isSuccess = await ServiceManager!.JobCategoryService.DeleteCategory(categoryId);
                if (isSuccess)
                {
                    Snackbar!.Add($"Successfully deleted category", Severity.Success);
                    await GetAllJobsCategories();
                }
            }

        }
        public async Task GetAllJobsCategories()
        {
            var categories = await ServiceManager!.JobCategoryService.GetAllCategoriesAsync();
            if (categories != null)
                _categories = new ObservableCollection<Category>(categories);

        }

        //Table search methods
        public bool FilterFunc1(Category element) => FilterFunc(element, SearchStringCategories);
        private bool FilterFunc(Category element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;

            if (element.Name!.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        }


        public ObservableCollection<Category> Categories
        {
            get { return _categories; }
            set { SetValue(ref _categories, value); }
        }

        public String SearchStringCategories
        {
            get { return _searchStringCategories!; }
            set { SetValue(ref _searchStringCategories, value); }
        }


    }

}
