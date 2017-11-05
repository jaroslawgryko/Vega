using Microsoft.EntityFrameworkCore;
using Vega.Models;

namespace Vega.Persistence
{
  public class VegaDbContext : DbContext
  {
    public DbSet<Pojazd> Pojazdy { get; set; }
    public DbSet<Marka> Marki { get; set; }
    public DbSet<Atrybut> Atrybuty { get; set; }
    
    public VegaDbContext(DbContextOptions<VegaDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<PojazdAtrybut>().HasKey(
        pa => new { pa.PojazdId, pa.AtrybutId }
      );
    }
  }
}