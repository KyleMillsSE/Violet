using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DotNetCore2.Model.Entities
{
    public class AuthToken
    {
        [Required, StringLength(100), Column(Order = 1)]
        public string ClientId { get; set; }

        [Required, StringLength(100), Column(Order = 2)]
        public string RefreshToken { get; set; }

        [Required, Column(Order = 3)]
        public bool IsStop { get; set; }
    }
}
