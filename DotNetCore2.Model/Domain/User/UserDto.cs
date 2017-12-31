using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore2.Model.Domain.User
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
