namespace SystemDuo.Core.Dto
{
    public class AuthDto
    {
        public bool IsAuthenticated { get; set; }
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public string Name {get; set;} = string.Empty;
        public string Surname {get; set;} = string.Empty;
    }
}
