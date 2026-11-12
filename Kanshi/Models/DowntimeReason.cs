namespace Kanshi.Models
{
    public class DowntimeReason
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public int ProductionOrderDowntimeReasonId { get; set; } = 0;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<ProductionOrderDowntimeReason> ProductionOrders { get; set; }
            = new List<ProductionOrderDowntimeReason>();
    }
}