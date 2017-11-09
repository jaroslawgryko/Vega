using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vega.Core.Models
{
    [Table("Modele")]
    public class Model
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Nazwa { get; set; }


        // inverse property navigation property + foreign key
        public Marka Marka { get; set; }    
        public int MarkaId { get; set; }    
    }
}