namespace Kanshi.Models
{

    public class ProductionOrderNonQuality
    {
        public int Id { get; set; }

        public int ProductionOrderId { get; set; }
        public ProductionOrder ProductionOrder { get; set; } = null!;

        public int NonQualityId { get; set; }
        public NonQuality NonQuality { get; set; } = null!;
    }
}