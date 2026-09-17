using Microsoft.EntityFrameworkCore;

namespace Kanshi.Data;
public class KanshiDbContext : DbContext
{
    public KanshiDbContext(DbContextOptions<KanshiDbContext> options)
        : base(options)
    {
    }
    public DbSet<Kanshi.Models.Users> Users { get; set; } = null!;
}
