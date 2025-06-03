using AnimalsWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AnimalsWeb.Controllers
{
    public class AnimalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnimalsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // -------------------------------------------------------------------------
        //CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Animal animalViewModel)
        {
            if (ModelState.IsValid)
            {
                var animal = new Animal
                {
                    Class = animalViewModel.Class,
                    Age = animalViewModel.Age,
                    Species = animalViewModel.Species,
                    Weight = animalViewModel.Weight
                };

                _context.Animals.Add(animal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(animalViewModel);
        }
        // -------------------------------------------------------------------------
        // EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Animals.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Animal animal)
        {
            if (id != animal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalExist(animal.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(animal);
        }
        // -------------------------------------------------------------------------
        //INDEX
        public async Task<IActionResult> Index(string search)
        {
            var animals = _context.Animals.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                animals = animals.Where(c => c.Class.Contains(search) || c.Species.Contains(search));
            }

            var animalList = await animals.ToListAsync();

            return View(animalList);
        }
        // -------------------------------------------------------------------------
        //IS EXIST
        private bool AnimalExist(int id)
        {
            return _context.Animals.Any(c => c.Id == id);
        }
        // -------------------------------------------------------------------------
        //Detales
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }
        // -------------------------------------------------------------------------
        //DELETE        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // POST:
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animal = await _context.Animals.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }

            _context.Animals.Remove(animal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}