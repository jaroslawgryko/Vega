using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Vega.Controllers.Resources
{
    public class PojazdResource
    {
        public int Id { get; set; }
        public KeyValuePairResource Model { get; set; }
        public KeyValuePairResource Marka { get; set; }
        public bool CzyZarejestrowany { get; set; }
        public KontaktResources Kontakt { get; set; }
        public DateTime OstatniaZmiana { get; set; }
        public ICollection<KeyValuePairResource> Atrybuty { get; set; }

        public PojazdResource()
        {
            Atrybuty = new Collection<KeyValuePairResource>();
        }        
    }
}