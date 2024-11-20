namespace Smartkitchen.API.Models
{
    public class UserBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; } = string.Empty;
    }
}
