namespace Kanshi.Models
{
    public class NonQuality
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<ProductionOrderNonQuality> ProductionOrders { get; set; }
        = new List<ProductionOrderNonQuality>();

    }
}