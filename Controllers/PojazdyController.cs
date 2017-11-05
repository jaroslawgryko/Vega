using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vega.Controllers.Resources;
using Vega.Models;
using Vega.Persistence;

namespace Vega.Controllers
{
    [Route("/api/pojazdy")]
    public class PojazdyController : Controller
    {
        private readonly IMapper mapper;
        private readonly VegaDbContext context;
        public PojazdyController(IMapper mapper, VegaDbContext context)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePojazd([FromBody] PojazdResource pojazdResource)
        {
            var pojazd = mapper.Map<PojazdResource, Pojazd>(pojazdResource);
            pojazd.OstatniaZmiana = DateTime.Now;

            context.Pojazdy.Add(pojazd);
            await context.SaveChangesAsync();

            var result = mapper.Map<Pojazd, PojazdResource>(pojazd);

            return Ok(result);
        }
    }
}