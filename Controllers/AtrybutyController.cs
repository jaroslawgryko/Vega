using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vega.Controllers.Resources;
using Vega.Core.Models;
using Vega.Persistence;

namespace Vega.Controllers
{
    public class AtrybutyController : Controller
    {
        private readonly VegaDbContext context;
        private readonly IMapper mapper;

        public AtrybutyController(VegaDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("/api/atrybuty")]
        public async Task<IEnumerable<KeyValuePairResource>> GetAtrybuty()
        {
            var atrybuty = await context.Atrybuty.ToListAsync();

            return mapper.Map<List<Atrybut>, List<KeyValuePairResource>>(atrybuty);
        }
    }
}