using Microsoft.AspNetCore.Mvc;
using Vega.Models;

namespace Vega.Controllers
{
    [Route("/api/pojazdy")]
    public class PojazdyController : Controller
    {
        [HttpPost]
        public IActionResult CreatePojazd([FromBody] Pojazd pojazd)
        {
            return Ok(pojazd);
        }
    }
}