using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vega.Core;
using Vega.Core.Models;

namespace Vega.Persistence
{
    public class PojazdRepository : IPojazdRepository
    {
        private readonly VegaDbContext context;
        public PojazdRepository(VegaDbContext context)
        {
            this.context = context;

        }
        public async Task<Pojazd> GetPojazd(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.Pojazdy.FindAsync(id);

            return await context.Pojazdy
                .Include(p => p.Atrybuty)
                    .ThenInclude(pa => pa.Atrybut)
                .Include(p => p.Model)
                    .ThenInclude(m => m.Marka)
                .SingleOrDefaultAsync(p => p.Id == id);
        }
        public void Add(Pojazd pojazd)
        {
            context.Pojazdy.Add(pojazd);
        }
        public void Remove(Pojazd pojazd)
        {
            context.Pojazdy.Remove(pojazd);
        }
    }
}