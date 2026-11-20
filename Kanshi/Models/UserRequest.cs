namespace Kanshi.Models
{
    public class UserRequest
    {
        public string Lastname { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        public string RegistrationNumber { get; set; } = string.Empty;
        public string Password { get; set; } = null!;
    }
}
