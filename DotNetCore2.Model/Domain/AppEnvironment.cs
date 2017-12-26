using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore2.Model.Domain
{
    public class AppEnvironment
    {
        public string Seeding { get; set; }
        public string PasswordSalt { get; set; }
    }
}
