using System.Collections.Generic;
using System.Collections.ObjectModel;
using Vega.Models;

namespace Vega.Controllers.Resources
{
    public class MarkaResource
    {
        public int Id { get; set; } 
        public string Nazwa { get; set; }
        public ICollection<ModelResource> Modele { get; set; }
        public MarkaResource()
        {
            Modele = new Collection<ModelResource>();
        }        
    }
}