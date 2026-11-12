using Microsoft.EntityFrameworkCore;
using Kanshi.Models;

namespace Kanshi.Data
{
    public class KanshiDbContext : DbContext
    {
        public KanshiDbContext(DbContextOptions<KanshiDbContext> options)
            : base(options)
        {
        }

        public DbSet<Machine> Machines { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<FinalProduct> FinalProducts { get; set; }
        public DbSet<RawMaterial> RawMaterials { get; set; }
        public DbSet<ProductionOrder> ProductionOrders { get; set; }
        public DbSet<NonQuality> NonQualities { get; set; }
        public DbSet<DowntimeReason> DowntimeReasons { get; set; }

        public DbSet<ProductionOrderNonQuality> ProductionOrderNonQualities { get; set; }
        public DbSet<ProductionOrderDowntimeReason> ProductionOrderDowntimeReasons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relation ProductionOrder - NonQuality
            modelBuilder.Entity<ProductionOrderNonQuality>()
                .HasKey(x => new { x.ProductionOrderId, x.NonQualityId });

            modelBuilder.Entity<ProductionOrderNonQuality>()
                .HasOne(x => x.ProductionOrder)
                .WithMany(x => x.NonQualities)
                .HasForeignKey(x => x.ProductionOrderId);

            modelBuilder.Entity<ProductionOrderNonQuality>()
                .HasOne(x => x.NonQuality)
                .WithMany(x => x.ProductionOrders)
                .HasForeignKey(x => x.NonQualityId);


            // Relation ProductionOrder - DowntimeReason
            modelBuilder.Entity<ProductionOrderDowntimeReason>()
                .HasKey(x => new { x.ProductionOrderId, x.DowntimeReasonId });

            modelBuilder.Entity<ProductionOrderDowntimeReason>()
                .HasOne(x => x.ProductionOrder)
                .WithMany(x => x.DowntimeReasons)
                .HasForeignKey(x => x.ProductionOrderId);

            modelBuilder.Entity<ProductionOrderDowntimeReason>()
                .HasOne(x => x.DowntimeReason)
                .WithMany(x => x.ProductionOrders)
                .HasForeignKey(x => x.DowntimeReasonId);
        }
    }
}