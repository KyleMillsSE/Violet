namespace DotNetCore2.Model.Domain.Auth
{
    public class AuthenticationDto
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public int Expires { get; set; }

    }
}
