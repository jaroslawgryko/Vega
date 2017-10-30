using Microsoft.EntityFrameworkCore;
using Vega.Models;

namespace Vega.Persistence
{
  public class VegaDbContext : DbContext
  {
    public DbSet<Marka> Marki { get; set; }
    public DbSet<Atrybut> Atrybuty { get; set; }
    
    public VegaDbContext(DbContextOptions<VegaDbContext> options)
        : base(options)
    {
    }
  }
}