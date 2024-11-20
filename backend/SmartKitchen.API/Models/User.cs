namespace Smartkitchen.API.Models
{
    public class User : UserBase
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }      
    }
}
