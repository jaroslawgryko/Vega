using System.Collections.Generic;
using System.Threading.Tasks;
using Vega.Core.Models;

namespace Vega.Core
{
    public interface IPojazdRepository
    {
         Task<Pojazd> GetPojazd(int id, bool includeRelated = true);

         void Add(Pojazd pojazd);
         void Remove(Pojazd pojazd);
         Task<QueryResult<Pojazd>> GetPojazdy(PojazdQuery filter);
    }
}