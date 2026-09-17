namespace Kanshi.Models
{
    public class UserRequest
    {
        public string Lastname { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        public int RegistrationNumber { get; set; } = 0;
        public string Password { get; set; } = null!;
    }
}
