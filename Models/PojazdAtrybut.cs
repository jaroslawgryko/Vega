using System.ComponentModel.DataAnnotations.Schema;

namespace Vega.Models
{   
    [Table("PojazdAtrybuty")]
    public class PojazdAtrybut
    {
        public int PojazdId { get; set; }       //foreinkey property
        public int AtrybutId { get; set; }      //foreinkey property
        public Pojazd Pojazd { get; set; }      //navigation property
        public Atrybut Atrybut { get; set; }    //navigation property
    }
}