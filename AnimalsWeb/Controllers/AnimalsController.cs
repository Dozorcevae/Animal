using Microsoft.AspNetCore.Mvc;
using AnimalslWeb.Data;
using AnimalsWeb.Models;
using AnimalsWeb.Data;


namespace AnimalsWeb.Controllers
{
    public class AnimalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnimalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // get some animals if u know what i mean
        public IActionResult Create()
        {
            return View();
        }

        // post some animals... well, u know
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Animal animal)
        {
            if (ModelState.IsValid)
            {
                _context.Animals.Add(animal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(animal);
        }

        // get animals
        public IActionResult Index()
        {
            return View(_context.Animals.ToList());
        }
    }
}