using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vega.Controllers.Resources;
using Vega.Core;
using Vega.Core.Models;

namespace Vega.Controllers
{
    // /api/pojazdy/1/photos
    [Route("/api/pojazdy/{pojazdId}/photos")]
    public class PhotosController : Controller
    {
        private readonly IMapper mapper;
        private readonly IHostingEnvironment host;
        private readonly IPojazdRepository repository;
        private readonly IUnitOfWork unitOfWork;
        public PhotosController(
            IHostingEnvironment host, IPojazdRepository repository, 
            IUnitOfWork unitOfWork, IMapper mapper )
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.host = host;
            // host.WebRootPath  // ścieżka do wwwroot
        }

        [HttpPost]
        public async Task<IActionResult> Upload(int pojazdId, IFormFile file)
        {
            var pojazd = await repository.GetPojazd(pojazdId, includeRelated: false);
            if (pojazd == null)
                return NotFound();

            var uploadsFolderPath = Path.Combine(host.WebRootPath, "uploads");

            if (!Directory.Exists(uploadsFolderPath))
                Directory.CreateDirectory(uploadsFolderPath);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var photo = new Photo { FileName = fileName };
            pojazd.Photos.Add(photo);

            await unitOfWork.CompleteAsync();

            return Ok(mapper.Map<Photo, PhotoResource>(photo));
        }
    }
}