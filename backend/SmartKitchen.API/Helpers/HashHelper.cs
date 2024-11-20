namespace Smartkitchen.API.Utils
{
    public class HashHelper
    {
        public static string GenerateHashPassword (string password)
        {
            var salt = BCrypt.GenerateSalt(12)
        }
    }
}
