using Microsoft.EntityFrameworkCore;
using Vega.Core.Models;

namespace Vega.Persistence
{
  public class VegaDbContext : DbContext
  {
    public DbSet<Pojazd> Pojazdy { get; set; }
    public DbSet<Marka> Marki { get; set; }
    public DbSet<Model> Modele { get; set; }
    public DbSet<Atrybut> Atrybuty { get; set; }
    public DbSet<Photo> Photos { get; set; }
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