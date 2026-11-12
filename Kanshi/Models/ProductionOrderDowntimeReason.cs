namespace Kanshi.Models
{
    public class ProductionOrderDowntimeReason
    {
        public int ProductionOrderId { get; set; }
        public ProductionOrder ProductionOrder { get; set; } = null!;

        public int DowntimeReasonId { get; set; }
        public DowntimeReason DowntimeReason { get; set; } = null!;
    }
}