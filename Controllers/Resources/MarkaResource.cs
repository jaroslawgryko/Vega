using System.Collections.Generic;
using System.Collections.ObjectModel;
using Vega.Models;

namespace Vega.Controllers.Resources
{
    public class MarkaResource : KeyValuePairResource
    {
        public ICollection<KeyValuePairResource> Modele { get; set; }
        public MarkaResource()
        {
            Modele = new Collection<KeyValuePairResource>();
        }        
    }
}