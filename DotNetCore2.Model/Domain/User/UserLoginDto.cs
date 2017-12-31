using System.ComponentModel.DataAnnotations;

namespace DotNetCore2.Model.Domain.User
{
    public class UserLoginDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string GrantType { get; set; }
    }
}
