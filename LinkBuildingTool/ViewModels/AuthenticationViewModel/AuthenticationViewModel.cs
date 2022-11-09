using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using LinkBuildingTool.Core.Dto;
using LinkBuildingTool.Helpers;

namespace LinkBuildingTool.ViewModels
{
    public class AuthenticationViewModel:BaseViewModel
    {
        public string SuccessMessage { get; set; } =string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;

        private ForgotPassword _forgotPassword = new();
        private ResetPassword _resetPassword = new();
        private ChangePassword _changePassword = new();
       
        [Inject]
        private TokenAuthenticationStateProvider? AuthenticationStateProvider { get; set; }
        public async Task SendForgotPasswordEmail()
        {

            var authResult = await ServiceManager!.UserService!.SendForgotPasswordEmail(_forgotPassword);
            if (!authResult.IsSuccess)
            {
                ErrorMessage = authResult!.Message;
                SuccessMessage = "";
                //emailSend = false;
            }
            else
            {
                SuccessMessage = authResult!.Message;
                ErrorMessage = "";
            }
           // emailSend = true;
           // _forgotPassword = new();

        }
        public void GetHttpParameters()
        {
            var uriBuilder = new UriBuilder(NavigationManager!.Uri);
            var httpQuery = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);
            _resetPassword.Email = httpQuery["email"] ?? "";
            _resetPassword.ResetPasswordToken = httpQuery["token"] ?? "";

        }
        public async Task ResetUserPassword()
        {

            var authResult = await ServiceManager!.UserService.ResetPassword(_resetPassword);
            if (!authResult.IsSuccess)
            {
                ErrorMessage = authResult!.Message;
                SuccessMessage = "";
            }
            else
            {
                SuccessMessage= authResult!.Message;
                ErrorMessage = "";
            }
                
           
            _resetPassword = new();

        }
        public async Task ChangeUserPassword()
        {

            var authState = await AuthenticationStateProvider!.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user!.Identity!.IsAuthenticated)
            {
                var _authMessage = $"{user.Identity.Name} is authenticated.";
                var _claims = user.Claims;
                var email = user.FindFirst(c => c.Type == ClaimTypes.Name)?.Value;


                var authResult = await ServiceManager!.UserService!.ChangePassword(email!, _changePassword);
                if (!authResult.IsSuccess)

                {
                  
                    ErrorMessage = authResult.Message!;
                    SuccessMessage = "";
                }
                else
                {
                  
                    SuccessMessage = authResult.Message!;
                    ErrorMessage = "";
                    _changePassword = new();
                }

            }
            else
            {
                // _authMessage = "The user is NOT authenticated.";
            }


        }
        public ResetPassword ResetPassword
        {
            get => _resetPassword;
            set { SetValue(ref _resetPassword, value); }
        }
        public ForgotPassword ForgotPassword
        {
            get { return _forgotPassword; }
            set { _forgotPassword = value; }
        }
        public ChangePassword ChangePassword
        {
            get { return _changePassword; }
            set
            {
                SetValue(ref _changePassword, value);
            }
        }
    }
}
