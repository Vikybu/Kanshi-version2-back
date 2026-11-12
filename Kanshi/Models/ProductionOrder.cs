namespace Kanshi.Models
{
    public class ProductionOrder
    {
        public int Id { get; set; }

        public string ProductionOrderNumber { get; set; } = null!;
        public string Status { get; set; } = null!;

        public int MachineId { get; set; }
        public int UsersId { get; set; }
        public int FinalProductId { get; set; }
        public int RawMaterialId { get; set; }

        public Machine Machine { get; set; } = null!;
        public Users Users { get; set; } = null!;
        public FinalProduct FinalProduct { get; set; } = null!;
        public RawMaterial RawMaterial { get; set; } = null!;

        public int RawMaterialQuantity { get; set; }
        public int TheoreticalFinalProductQuantity { get; set; }
        public int RealFinalProductQuantity { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Relations Many-to-Many via tables intermédiaires
        public ICollection<ProductionOrderNonQuality> NonQualities { get; set; }
            = new List<ProductionOrderNonQuality>();

        public ICollection<ProductionOrderDowntimeReason> DowntimeReasons { get; set; }
            = new List<ProductionOrderDowntimeReason>();
    }
}