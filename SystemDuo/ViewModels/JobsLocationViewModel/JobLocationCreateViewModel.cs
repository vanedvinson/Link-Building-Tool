using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.ObjectModel;
using SystemDuo.Core.Domain;
using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Services.Abstractions;
using MudBlazor.Dialog;

namespace SystemDuo.ViewModels
{
    public class JobLocationCreateViewModel:BaseViewModel
    {
        private ObservableCollection<Location> _jobLocations = new();
        private Location _jobLocation = new();
        [CascadingParameter] MudDialogInstance? MudDialog { get; set; }
        protected override void OnInitialized()
        {

            PropertyChanged += async (sender, e) =>
            {
                await InvokeAsync(() =>
                {
                    
                    StateHasChanged();
                });

            };
           
        }



        public void Cancel()
        {
            MudDialog!.Cancel();
            
        }
        
       
        public async Task CreateJobLocations()
        {


            if (JobLocation.Id != Guid.Empty)
            {
                var ress = await ServiceManager!.JobService.UpdateLocation(JobLocation);
                if (ress)
                {
                    MudDialog!.Close();
                }
            }
            else
            {
                var res = await ServiceManager!.JobService.CreateLocation(JobLocation);
                if (res)
                {
                    Snackbar!.Add("Successfully created", Severity.Success);
                    MudDialog!.Close();
                }
                    
            }
        }

        public ObservableCollection<Location> JobLocations
        {
            get { return _jobLocations; }
            set { SetValue(ref _jobLocations, value); }
        }
        [Parameter]
        public Location JobLocation
        {
            get { return _jobLocation; }
            set { SetValue(ref _jobLocation, value); }
        }
      

    }
}

