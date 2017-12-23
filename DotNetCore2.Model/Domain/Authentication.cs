using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore2.Model.Domain
{
    public class Authentication
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public int Expires { get; set; }

    }
}
