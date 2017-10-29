using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Vega.Models
{
    public class Marka
    {
        public int Id { get; set; } 
        public string Nazwa { get; set; }
        public ICollection<Model> Modele { get; set; }
        public Marka()
        {
            Modele = new Collection<Model>();
        }
    }
}