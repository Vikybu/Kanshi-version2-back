namespace Kanshi.Models
{
    public class RawMaterial
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Reference { get; set; } = null!;
        public string MeasurementUnit { get; set; } = null!;
        public int TheoreticalInductrialPace { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<ProductionOrder> ProductionOrders { get; set; }
            = new List<ProductionOrder>();

    }
}