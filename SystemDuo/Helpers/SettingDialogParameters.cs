
using Microsoft.AspNetCore.Components;
using MudBlazor;
using SystemDuo.Components.Dialogs;
using SystemDuo.ViewModels;

namespace SystemDuo.Helpers
{
    public class SettingDialogParameters<T>:ComponentBase where T:ComponentBase
    {
        public string Title { get; set; }
        public object ContentText { get; set; } 
        public object ButtonText { get; set; } 
        public object ButtonColor { get; set; } = Color.Error;
        private  DialogParameters parameters = new DialogParameters();
       
        public IDialogService DialogService { get; set; }
        public SettingDialogParameters( IDialogService dialogService,string title,object contextText, object buttonText, object buttonColor)
        {
            ContentText = contextText; 
            ButtonText = buttonText;
            ButtonColor = buttonColor;
            DialogService = dialogService;
            Title = title;
    }
    
        public DialogParameters GetDialogParameter()
        {
            parameters.Add("ContentText", ContentText);
            parameters.Add("ButtonText", ButtonText);
            parameters.Add("Color", ButtonColor);

            return parameters;
        }
        public async Task<DialogResult> SetConfirmDialog()
        {
             
            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };

            var dialog = DialogService!.Show<T>(Title, GetDialogParameter(), options);
            return await dialog.Result;
        }


    }
}
