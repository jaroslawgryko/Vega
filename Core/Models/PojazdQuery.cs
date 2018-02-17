using Vega.Extensions;

namespace Vega.Core.Models
{
    public class PojazdQuery : IQueryObject
    {
        public int? MarkaId { get; set; }
        public int? ModelId { get; set; }
        public string Sortby { get; set; }
        public bool IsSortAscending { get; set; }
    }
}