namespace Kanshi.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Lastname { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        public int RegistrationNumber { get; set; } = 0;
        public string Role { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
