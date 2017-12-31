using CryptoHelper;

namespace DotNetCore2.Services.Utils
{
    public static class CryptoHelperWrapper
    {
        public static string HashPassword(string password)
        {
            return Crypto.HashPassword(password);
        }

        // Verify the password hash against the given password
        public static bool VerifyPassword(string hash, string password)
        {
            return Crypto.VerifyHashedPassword(hash, password);
        }
    }
}
