using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Vega.Core.Models
{
    public class Marka
    {
        public int Id { get; set; } 
        [Required]
        [StringLength(255)]
        public string Nazwa { get; set; }
        public ICollection<Model> Modele { get; set; }
        public Marka()
        {
            Modele = new Collection<Model>();
        }
    }
}