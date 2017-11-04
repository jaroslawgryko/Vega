using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vega.Controllers.Resources;
using Vega.Models;

namespace Vega.Controllers
{
    [Route("/api/pojazdy")]
    public class PojazdyController : Controller
    {
        private readonly IMapper mapper;
        public PojazdyController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreatePojazd([FromBody] PojazdResource pojazdResource)
        {
            var pojazd = mapper.Map<PojazdResource, Pojazd>(pojazdResource);
            return Ok(pojazd);
        }
    }
}