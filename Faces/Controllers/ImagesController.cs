using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Faces.Domain.Entities;
using Faces.Persistence;
using Faces.Application.Interfaces;
using Faces.Application.Models;

namespace Faces.Controllers
{
    public class ImagesController : Controller
    {
        private readonly FacesDbContext _context;

        private IFacePlusPlusService FacePlusPlusService
        {
            get;
        }

        public ImagesController(FacesDbContext context, IFacePlusPlusService facePlusPlusService)
        {
            _context = context;
            this.FacePlusPlusService = facePlusPlusService;
        }

        // GET: Images
        public async Task<IActionResult> Index()
        {
            return View(await _context.Images.ToListAsync());
        }

        // GET: Images/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Images
                .FirstOrDefaultAsync(m => m.Id == id);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }

        // GET: Images/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Images/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ImageUrl,Age,Sex")] Image image)
        {
            if (ModelState.IsValid)
            {
                _context.Add(image);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(image);
        }

        public async Task<IActionResult> EvaluationDetails(int id)
        {
            var image = await _context.Images.FindAsync(id);

            var response = await this.FacePlusPlusService.DetectFace(image.ImageUrl);

            var imageViewModel = new ImageViewModel
            {
                OriginalImage = image,
                NeuralResult = response
            };

            return View(imageViewModel);
        }
    }
}
