using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SystemDuo.Core.Services.Abstractions;

namespace SystemDuo.ViewModels
{
    public abstract class BaseViewModel :ComponentBase, INotifyPropertyChanged
    {
        [Inject]
        public IServiceManager? ServiceManager { get; set; }
        [Inject]
        public NavigationManager? NavigationManager { get; set; }
        [Inject]
        public IDialogService? DialogService { get; set; } 
        [Inject]
        public ISnackbar? Snackbar { get; set; }
        private bool isBusy = false;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                SetValue(ref isBusy, value);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected void SetValue<T>(ref T backingFiled, T value, [CallerMemberName] string propertyName = null!)
        {
            if (EqualityComparer<T>.Default.Equals(backingFiled, value)) return;
            backingFiled = value;
            OnPropertyChanged(propertyName);
        }
    }
}
