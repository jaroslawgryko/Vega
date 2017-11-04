using System.ComponentModel.DataAnnotations;

namespace Vega.Controllers.Resources
{
    public class KontaktResources
    {
        [Required]
        [StringLength(255)]        
        public string Nazwa { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        [StringLength(255)]
        public string Telefon { get; set; }
    }
}