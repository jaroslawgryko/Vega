using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vega.Models
{
    [Table("Pojazdy")]
    public class Pojazd
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public bool CzyZarejestrowany { get; set; }
        [Required]
        [StringLength(255)]
        public string KontaktNazwa { get; set; }
        [StringLength(255)]
        public string KontaktEmail { get; set; }
        [Required]
        [StringLength(255)]
        public string KontaktTelefon { get; set; }
        public DateTime OstatniaZmiana { get; set; }
        public ICollection<PojazdAtrybut> Atrybuty { get; set; }

        public Pojazd()
        {
            Atrybuty = new Collection<PojazdAtrybut>();
        }
    }
}