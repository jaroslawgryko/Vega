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
        private readonly IPojazdRepository repository;
        private readonly IUnitOfWork unitOfWork;
        public PojazdyController(IMapper mapper, IPojazdRepository repository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;            
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePojazd([FromBody] SavePojazdResource pojazdResource)
        {
            //server side validation
            if (!ModelState.IsValid)                //validation against domain model
                return BadRequest(ModelState);

            // if (true)
            // {
            //     ModelState.AddModelError("...", "error"); // against some b. rull
            //     return BadRequest(ModelState);
            // }

            var pojazd = mapper.Map<SavePojazdResource, Pojazd>(pojazdResource);
            pojazd.OstatniaZmiana = DateTime.Now;

            repository.Add(pojazd);
            await unitOfWork.CompleteAsync();

            pojazd = await repository.GetPojazd(pojazd.Id);

            var result = mapper.Map<Pojazd, PojazdResource>(pojazd);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePojazd(int id, [FromBody] SavePojazdResource pojazdResource)
        {
            //server side validation
            if (!ModelState.IsValid)                //validation against domain model
                return BadRequest(ModelState);

            var pojazd = await repository.GetPojazd(id);

            if (pojazd == null)
                return NotFound();

            mapper.Map<SavePojazdResource, Pojazd>(pojazdResource, pojazd);
            pojazd.OstatniaZmiana = DateTime.Now;

            await unitOfWork.CompleteAsync();

            pojazd = await repository.GetPojazd(pojazd.Id);            
            var result = mapper.Map<Pojazd, PojazdResource>(pojazd);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePojazd(int id)
        {
            var pojazd = await repository.GetPojazd(id, includeRelated: false);
            if (pojazd == null)
                return NotFound();

            repository.Remove(pojazd);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPojazd(int id)
        {
            var pojazd = await repository.GetPojazd(id);

            if (pojazd == null)
                return NotFound();

            var pojazdResource = mapper.Map<Pojazd, PojazdResource>(pojazd);

            return Ok(pojazdResource);
        }

    }
}