namespace Kanshi.Models
{
    public class FinalProduct
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public int QuantityofProduct { get; set; } = 0;
        public string MeasurementUnit { get; set; } = null!;
        public string Reference { get; set; } = null!;
        public bool IsActive { get; set; } = true;
        public int TheoreticalIndustrialPace { get; set; } = 0;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<ProductionOrder> ProductionOrders { get; set; }
            = new List<ProductionOrder>();

    }
}