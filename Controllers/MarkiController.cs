using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vega.Controllers.Resources;
using Vega.Models;
using Vega.Persistence;

namespace Vega.Controllers
{
    public class MarkiController : Controller
    {
        private readonly VegaDbContext context;
        private readonly IMapper mapper;
        public MarkiController(VegaDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("/api/marki")]
        public async Task<IEnumerable<MarkaResource>> GetMarki()
        {
            var marki = await context.Marki.Include(m => m.Modele).ToListAsync();

            return mapper.Map<List<Marka>, List<MarkaResource>>(marki);
        }
    }
}