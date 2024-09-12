using System;
using System.Security.Cryptography;
using System.Text;


namespace WebApp_EstanteVirtual.Services
{
    public class CryptographyService
    {
        public static string EncryptPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var passwordHashBytes = sha256.ComputeHash(passwordBytes);
            return Convert.ToBase64String(passwordHashBytes);
        }
    }
}