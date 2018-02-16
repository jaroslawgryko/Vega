namespace Vega.Core.Models
{
    public class PojazdQuery
    {
        public int? MarkaId { get; set; }
        public int? ModelId { get; set; }
        public string Sortby { get; set; }
        public bool IsSortAscending { get; set; }
    }
}