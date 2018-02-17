using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vega.Core;
using Vega.Core.Models;
using Vega.Extensions;

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

        public async Task<IEnumerable<Pojazd>> GetPojazdy(PojazdQuery queryObj)
        {
            var query = context.Pojazdy
                .Include(v => v.Model)
                    .ThenInclude(m => m.Marka)
                .Include(v => v.Atrybuty)
                    .ThenInclude(vf => vf.Atrybut)
                .AsQueryable();

            if (queryObj.MarkaId.HasValue)
                query = query.Where(p => p.Model.MarkaId == queryObj.MarkaId.Value);
            
            if (queryObj.ModelId.HasValue)
                query = query.Where(p => p.Model.Id == queryObj.ModelId.Value);

            // Func<Pojazd, string> func = p => p.KontaktNazwa;  // przykaład użycia funkcji anonimowej 
            // Expression<Func<Pojazd, string>> wyrazenie = p => p.KontaktNazwa;  // przykład użycia wyrażenia

            // Expression<Func<Pojazd, object>> exp;

            var columnsMap = new Dictionary<string, Expression<Func<Pojazd, object>>>()
            {
                ["marka"] = p => p.Model.Marka.Nazwa,
                ["model"] = p => p.Model.Nazwa,
                ["kontaktName"] = p => p.KontaktNazwa
            };

            // if (queryObj.IsSortAscending)            
            //     query = query.OrderBy(columnsMap[queryObj.Sortby]);
            // else
            //     query = query.OrderByDescending(columnsMap[queryObj.Sortby]);

            // if (queryObj.Sortby == "marka")
            //     query = (queryObj.IsSortAscending) ? query.OrderBy(p => p.Model.Marka.Nazwa) : query.OrderByDescending(p => p.Model.Marka.Nazwa);

            // if (queryObj.Sortby == "model")
            //     query = (queryObj.IsSortAscending) ? query.OrderBy(p => p.Model.Nazwa) : query.OrderByDescending(p => p.Model.Nazwa);

            // if (queryObj.Sortby == "kontaktNazwa")
            //                 query = (queryObj.IsSortAscending) ? query.OrderBy(p => p.KontaktNazwa) : query.OrderByDescending(p => p.KontaktNazwa);

            // if (queryObj.Sortby == "id")
            //                 query = (queryObj.IsSortAscending) ? query.OrderBy(p => p.Id) : query.OrderByDescending(p => p.Id);

            // query = ApplyOrdering(queryObj, query, columnsMap);

            query = query.ApplyOrdering(queryObj, columnsMap);

            return await query.ToListAsync();
     }



    }
}