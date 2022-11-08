using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.ObjectModel;
using SystemDuo.Components.Dialogs;
using SystemDuo.Components.JobLocationComponent;
using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Persistence;
using SystemDuo.Helpers;

namespace SystemDuo.ViewModels
{
    public class LocationsViewModel : BaseViewModel
    {
        private ObservableCollection<Location> _jobLocations = new();
        public string? searchString { get; set; }

        [Inject] 
        public RepositoryDbContext dbContext { get; set; }
        public string? _searchStringLocations;
        public string? _searchStringArchLocations;
        protected override async Task OnInitializedAsync()
        {

            PropertyChanged += async (sender, e) =>
            {
                await InvokeAsync(() =>
                {
                    StateHasChanged();
                });

            };

            await GetAllLocations();
        }
       
        public async Task GetAllLocations()
        {
            try
            {


                var locations = await ServiceManager!.JobService.GetAllJobLocationsAsync();
                if (locations != null)
                {
                    _jobLocations = new ObservableCollection<Location>(locations);
                }
            }
            catch (Exception ex)
            {

               await dbContext.DisposeAsync();
                var locations = await ServiceManager!.JobService.GetAllJobLocationsAsync();
                if (locations != null)
                {
                    _jobLocations = new ObservableCollection<Location>(locations);
                }
                //var loctions = await ServiceManager!.JobService.GetAllJobLocationsAsync();
                //if (locations != null)
                //{
                //    _jobLocations = new ObservableCollection<Location>(locations);
                //}
            }
        }
        public async Task OpenCreateJobLocation()
        {
            var parameter = new DialogParameters();
            parameter.Add("JobLocation", new Location());

            
            var dialog = DialogService!.Show<JobLocationFormComponent>("Create Job location",parameter);

            var res = await dialog.Result;
            if (!res.Cancelled)
            {
                await GetAllLocations();
            }
        }
        public async Task OpenUpdateJobLocation(Location jobLocation)
        {
            var parameter = new DialogParameters();
            parameter.Add("JobLocation",jobLocation);
            
            var dialog = DialogService!.Show<JobLocationFormComponent>("Edit Job location",parameter);

            var res = await dialog.Result;
            if (!res.Cancelled)
            {
                await GetAllLocations();

            }
        }

        public ObservableCollection<Location> JobLocations
        {
            get { return _jobLocations; }
            set { SetValue(ref _jobLocations, value); }
        }

        public async Task DeleteLocationAsync(Guid locationId)
        {
            var dialogResult = await SetConfirmDialog();
            if (!dialogResult.Cancelled)
            {
                var isSuccess = await ServiceManager!.JobService.DeleteLocation(locationId);
                if (isSuccess)
                {
                    await GetAllLocations();
                }
            }
        }

        public async Task UndoDeletedLocationAsync(Guid locationId)
        {
            var dialogResult = await SetUndoConfirmDialog();
            if (!dialogResult.Cancelled)
            {
                var isSuccess = await ServiceManager!.JobService.UndoDeletedLocation(locationId);
                if (isSuccess)
                {
                    await GetAllDeletedLocations();
                }
            }
        }
        public async Task GetAllDeletedLocations()
        {
            var locations = await ServiceManager!.JobService.GetAllDeletedLocationsAsync();
            if (locations != null)
            {
                _jobLocations = new ObservableCollection<Location>(locations);
            }
        }

        private async Task<DialogResult> SetConfirmDialog()
        {
            var settingsDialog = new SettingDialogParameters<ConfirmComponent>(DialogService!,"Confirm", "Do you want to delete this location?", "Delete", Color.Error);

            return await settingsDialog.SetConfirmDialog();

        }
        private async Task<DialogResult> SetUndoConfirmDialog()
        {
            var settingsDialog = new SettingDialogParameters<ConfirmComponent>(DialogService!, "Confirm", "Do you want to undo this location?", "Delete", Color.Error);

            return await settingsDialog.SetConfirmDialog();

        }

        //Table search methods
        public bool FilterFunc1(Location element) => FilterFunc(element, SearchStringLocations);
        public bool FilterFunc2(Location element) => FilterFunc(element, SearchStringArchLocations);
        private bool FilterFunc(Location element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;

            if (element.Address! is not null && element.Address!.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (element.City! is not null && element.City!.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (element.Country! is not null && element.Country!.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (element.PostalCode! is not null && element.PostalCode!.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        }

        public String SearchStringLocations
        {
            get { return _searchStringLocations!; }
            set { SetValue(ref _searchStringLocations, value); }
        }
        public String SearchStringArchLocations
        {
            get { return _searchStringArchLocations!; }
            set { SetValue(ref _searchStringArchLocations, value); }
        }

    }
}
