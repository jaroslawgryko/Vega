namespace Vega.Models
{
    public class Model
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }


        // inverse propery navigation property + foreign key
        public Marka Marka { get; set; }    
        public int MarkaId { get; set; }    
    }
}