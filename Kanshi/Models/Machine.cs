namespace Kanshi.Models
{
    public class Machine
    {
        public int Id { get; set; }
        public string LongName { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        public int Pace { get; set; } = 0;
        public string RawMaterialUsed { get; set; } = null!;
        public string FinalProductProducted { get; set; } = null!;
        public bool IsActive { get; set; } = true;
        public string Status { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<ProductionOrder> ProductionOrders { get; set; }
            = new List<ProductionOrder>();

    }
}