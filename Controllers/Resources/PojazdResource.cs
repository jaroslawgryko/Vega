using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Vega.Models;

namespace Vega.Controllers.Resources
{

    public class PojazdResource
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public bool CzyZarejestrowany { get; set; }
        [Required]
        public KontaktResources Kontakt { get; set; }
        public ICollection<int> Atrybuty { get; set; }

        public PojazdResource()
        {
            Atrybuty = new Collection<int>();
        }        
    }
}