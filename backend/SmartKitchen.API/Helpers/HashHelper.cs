using System.Security.Cryptography;

namespace Smartkitchen.API.Helpers
{
    public class HashHelper
    {
        public static string GenerateHashPassword(string password)
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // Define o número de iterações (quanto maior, mais seguro)
            int iterations = 10000;

            // Gera a chave derivada usando PBKDF2 com SHA256
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(32); // 32 bytes para o hash

                // Converte o hash para string (ex: Base64)
                return Convert.ToBase64String(hash);
            }
        }
    }
}
