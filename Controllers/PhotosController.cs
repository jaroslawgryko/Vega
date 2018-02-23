using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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
        private readonly IPhotoRepository photoRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly PhotoSettings photoSettings;
        public PhotosController(
            IHostingEnvironment host, IPojazdRepository repository, 
            IUnitOfWork unitOfWork, IMapper mapper, IOptionsSnapshot<PhotoSettings> options,
            IPhotoRepository photoRepository )
        {
            this.photoSettings = options.Value;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.photoRepository = photoRepository;
            this.host = host;
            // host.WebRootPath  // ścieżka do wwwroot
        }

        [HttpPost]
        public async Task<IActionResult> Upload(int pojazdId, IFormFile file)
        {
            var pojazd = await repository.GetPojazd(pojazdId, includeRelated: false);
            if (pojazd == null)
                return NotFound();

            if (file == null) return BadRequest("Brak pliku");
            if (file.Length == 0) return BadRequest("Pusty plik");
            if (file.Length > photoSettings.MaxBytes) return BadRequest("Plik zbyt duży");
            if (!photoSettings.IsSupported(file.FileName)) return BadRequest("Nieprawidłowy typ pliku");

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

        [HttpGet]
        public async Task<IEnumerable<PhotoResource>> GetPhotos(int pojazdId)
        {
            var photos = await photoRepository.GetPhotos(pojazdId);

            return mapper.Map<IEnumerable<Photo>, IEnumerable<PhotoResource>>(photos);
        }
    }
}