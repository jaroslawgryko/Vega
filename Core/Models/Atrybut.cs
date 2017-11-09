using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vega.Core.Models
{
    [Table("Atrybuty")]
    public class Atrybut
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Nazwa { get; set; }
    }
}