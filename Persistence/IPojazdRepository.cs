using System.Threading.Tasks;
using Vega.Models;

namespace Vega.Persistence
{
    public interface IPojazdRepository
    {
         Task<Pojazd> GetPojazd(int id, bool includeRelated = true);

         void Add(Pojazd pojazd);
         void Remove(Pojazd pojazd);
    }
}