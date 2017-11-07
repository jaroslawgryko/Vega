using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Vega.Controllers.Resources
{
    public class PojazdResource
    {
        public int Id { get; set; }
        public ModelResource Model { get; set; }
        public MarkaResource Marka { get; set; }
        public bool CzyZarejestrowany { get; set; }
        public KontaktResources Kontakt { get; set; }
        public DateTime OstatniaZmiana { get; set; }
        public ICollection<AtrybutResource> Atrybuty { get; set; }

        public PojazdResource()
        {
            Atrybuty = new Collection<AtrybutResource>();
        }        
    }
}