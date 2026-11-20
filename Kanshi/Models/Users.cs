namespace Kanshi.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Lastname { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        public string RegistrationNumber { get; set; } = string.Empty;
        public string Role { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<ProductionOrder> ProductionOrders { get; set; }
            = new List<ProductionOrder>();

    }
}
