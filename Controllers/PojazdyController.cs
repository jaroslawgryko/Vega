using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            //server side validation
            if (!ModelState.IsValid)                //validation against domain model
                return BadRequest(ModelState);

            // if (true)
            // {
            //     ModelState.AddModelError("...", "error"); // against some b. rull
            //     return BadRequest(ModelState);
            // }

            var pojazd = mapper.Map<PojazdResource, Pojazd>(pojazdResource);
            pojazd.OstatniaZmiana = DateTime.Now;

            context.Pojazdy.Add(pojazd);
            await context.SaveChangesAsync();

            var result = mapper.Map<Pojazd, PojazdResource>(pojazd);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePojazd(int id, [FromBody] PojazdResource pojazdResource)
        {
            //server side validation
            if (!ModelState.IsValid)                //validation against domain model
                return BadRequest(ModelState);

            var pojazd = await context.Pojazdy.Include(p => p.Atrybuty).SingleOrDefaultAsync(p => p.Id == id);

            if(pojazd == null)
                return NotFound();

            mapper.Map<PojazdResource, Pojazd>(pojazdResource, pojazd);
            pojazd.OstatniaZmiana = DateTime.Now;

            await context.SaveChangesAsync();

            var result = mapper.Map<Pojazd, PojazdResource>(pojazd);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePojazd(int id)
        {
            var pojazd = await context.Pojazdy.FindAsync(id);

            if(pojazd == null)
                return NotFound();

            context.Remove(pojazd);
            await context.SaveChangesAsync();

            return Ok(id);
        }
        
    }
}