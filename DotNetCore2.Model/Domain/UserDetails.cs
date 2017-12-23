using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DotNetCore2.Model.Domain
{
    public class UserDetails
    {
        [Required]

        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string GrantType { get; set; }
    }
}
