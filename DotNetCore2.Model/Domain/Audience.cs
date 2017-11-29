using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore2.Model.Domain
{
    public class Audience
    {
        public string Secret { get; set; }
        public string Iss { get; set; }
        public string Aud { get; set; }
    }
}
