namespace Kanshi.DTOs
{
    public class AuthResponse
    {
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }

        public int Id { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string RegistrationNumber { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}