using Faces.Application.Interfaces;
using Faces.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Faces.Controllers
{
    public class ImageController : Controller
    {
        private IFacesDbContext DbContext
        {
            get;
        }
        public ImageController(IFacesDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UploadImage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateImage(Image image, CancellationToken cancellationToken)
        {
            await this.DbContext.Images.AddAsync(image);
            await this.DbContext.SaveChangesAsync(cancellationToken);

            return RedirectToAction("ViewImage");
        }

        [HttpGet]
        public async Task<IActionResult> ViewImage(int imageId)
        {
            var image = this.DbContext.Images.FirstOrDefault(x => x.Id == imageId);
            return View(image);
        }

        [HttpPost]
        public async Task<IActionResult> DetectFace()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ViewFaceLandmarks()
        {
            return View();
        }
    }
}
