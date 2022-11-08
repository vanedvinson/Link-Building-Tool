using SystemDuo.Core.Domain.Entities;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.ObjectModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SystemDuo.ViewModels
{
    public class DomainCreateUpdateViewModel:BaseViewModel
    {
        private ClientDomain  _domain = new();
        private Webmaster _webmaster = new();
        private ObservableCollection<Webmaster> _webmasters = new();
        private Webmaster _selectedWebmaster = new();

        //parameter is set when update is selected
        [Parameter] public Guid domainId { get; set; }

        protected override async Task OnInitializedAsync()
        {

            PropertyChanged += async (sender, e) =>
            {
                await InvokeAsync(() =>
                {
                    StateHasChanged();
                });

            };

            if (domainId != Guid.Empty)
            {
                await GetDomainByIdAsync(domainId);
                SelectedWebmaster = Domain.Webmaster!;
            }
            else
            {
                SelectedWebmaster = Webmasters.FirstOrDefault();
            }

            await GetAllWebmasters();


        }

        public async Task CreateOrUpdateDomain()
        {
            if (Domain.Id != Guid.Empty)
            {
                Domain.Webmaster = SelectedWebmaster;
                var res = await ServiceManager!.DomainService.UpdateDomain(Domain);
                if (res)
                {
                    //TODO Add snackbar for success update
                    Snackbar!.Add("Successfully updated", Severity.Success);
                    Domain = new();
                    NavigationManager!.NavigateTo("/domains", false);
                }

            }
            else
            {
                Domain.Webmaster = SelectedWebmaster;
                var res = await ServiceManager!.DomainService.CreateDomain(Domain);
                if (res)
                {
                    //TODO Add snackbar for success create
                    Snackbar!.Add("Successfully created", Severity.Success);
                    Domain = new();
                    NavigationManager!.NavigateTo("/domains", false);
                }
            }




            // return res;
        }

        public async Task GetDomainByIdAsync(Guid id)
        {
            var res = await ServiceManager!.DomainService.GetDomainByIdAsync(id);
            if (res != null)
            {
                _domain = res;
                StateHasChanged();
            }
        }
        public async Task GetAllWebmasters()
        {
            var wm = await ServiceManager!.WebmasterService.GetAllWebmastersAsync();
            if (wm != null)
                _webmasters = new ObservableCollection<Webmaster>(wm);
        }



        public ClientDomain Domain
        {
            get { return _domain; }
            set { SetValue(ref _domain, value); }
        }
        public ObservableCollection<Webmaster> Webmasters
        {
            get { return _webmasters; }
            set { SetValue(ref _webmasters, value); }
        }
        public Webmaster Webmaster
        {
            get { return _webmaster; }
            set { SetValue(ref _webmaster, value); }
        }
        public Webmaster SelectedWebmaster
        {
            get { return _selectedWebmaster; }  
            set { SetValue(ref _selectedWebmaster, value); }
        }
    }
}
