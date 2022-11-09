using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace LinkBuildingTool.Helpers
{
    public class TokenStorage : ComponentBase
    {
        private readonly ProtectedLocalStorage localStorage;
        [Inject]
        NavigationManager navigationManager { get; set; }
        public TokenStorage(ProtectedLocalStorage localStorage)
        {
            this.localStorage = localStorage;
        }
        public async Task SetTokensAsync(string accessToken, string refreshToken)
        {
            await localStorage.SetAsync("accessToken", accessToken);
            await localStorage.SetAsync("refreshToken", refreshToken);
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            var token = await GetAccessToken();
        }
        public async Task<string> GetAccessToken()
        {
            try
            {
                var res = await localStorage.GetAsync<string>("accessToken");
                // StateHasChanged();
                //  RemoveTokens();

                return res.Value!;
            }
            catch
            {
                return string.Empty;
            }

        }
        public async Task<string> GetRefreshToken()
        {
            var res = await localStorage.GetAsync<string>("refreshToken");
            return res.Value!;

        }
        public async Task RemoveTokens()
        {
            await localStorage.DeleteAsync("accessToken");
            await localStorage.DeleteAsync("refreshToken");
        }

    }
}
