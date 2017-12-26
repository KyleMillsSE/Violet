using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore2.Services
{
    public class PasswordHasherService
    {
        public PasswordHasherService()
        {

        }
        
        public string HashPassword(string password)
        {
            var salt = "UIf4nzzr6JrSD5g0d09YeA==";

            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Encoding.ASCII.GetBytes(salt),
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }
    }
}
