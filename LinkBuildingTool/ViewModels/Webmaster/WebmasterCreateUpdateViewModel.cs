using LinkBuildingTool.Core.Domain.Entities;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.ComponentModel.Design;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LinkBuildingTool.ViewModels
{
    public class WebmasterCreateUpdateViewModel : BaseViewModel
    {
        private Webmaster _webmaster = new();

        //parameter is set when update is selected
        [Parameter] public Guid webmasterId { get; set; }

        protected override async Task OnInitializedAsync()
        {

            PropertyChanged += async (sender, e) =>
            {
                await InvokeAsync(() =>
                {
                    StateHasChanged();
                });

            };
            
            if (webmasterId != Guid.Empty) { 
                await GetWebmasterByIdAsync(webmasterId);
            }
        }

        public async Task GetWebmasterByIdAsync(Guid id)
        {
            var res = await ServiceManager!.WebmasterService.GetWebmasterByIdAsync(id);
            if (res != null)
            {
                _webmaster = res;
                StateHasChanged();
            }
        }


        public async Task CreateOrUpdateWebmaster()
        {
            if (Webmaster.Id != Guid.Empty)
            {
                //Webmaster.CategoryId = SelectedJobCategory.Id;
                var res = await ServiceManager!.WebmasterService.UpdateWebmaster(Webmaster);
                if (res)
                {
                    //TODO Add snackbar for success update
                    Snackbar!.Add("Successfully updated", Severity.Success);
                    Webmaster = new();
                    NavigationManager!.NavigateTo("/webmasters", false);
                }

            }
            else
            {
                var res = await ServiceManager!.WebmasterService.CreateWebmaster(Webmaster);
                if (res)
                {
                    //TODO Add snackbar for success create
                    Snackbar!.Add("Successfully created", Severity.Success);
                    Webmaster = new();
                    NavigationManager!.NavigateTo("/webmasters", false);
                }
            }




            // return res;
        }


        public Webmaster Webmaster
        {
            get { return _webmaster; }
            set { SetValue(ref _webmaster, value); }
        }

    }
}
