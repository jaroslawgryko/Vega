using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Vega.Core.Models;

namespace Vega.Controllers.Resources
{

    public class SavePojazdResource
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public bool CzyZarejestrowany { get; set; }
        [Required]
        public KontaktResources Kontakt { get; set; }
        public ICollection<int> Atrybuty { get; set; }

        public SavePojazdResource()
        {
            Atrybuty = new Collection<int>();
        }        
    }
}