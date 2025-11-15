using Microsoft.AspNetCore.Mvc;
using MVCCar.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace MVCCar.Controllers
{
    // CarsController mora naslijediti klasu Controller (nužno za MVC)
    public class CarsController : Controller
    {
        private readonly MVCCarContext _context;

        // Dependency Injection za bazu
        public CarsController(MVCCarContext context)
        {
            _context = context;
        }

        // Akcija za prikaz svih auta (Index View)
        public async Task<IActionResult> Index()
        {
            // Dohvati listu automobila iz baze i pošalji je View-u
            return View(await _context.Car.ToListAsync());
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Color,ProductionYear,Price,Manufacturer")] Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Edit/5 (Za uređivanje)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var car = await _context.Car.FindAsync(id);
            if (car == null) return NotFound();
            return View(car);
        }

        // GET: Cars/Details/5 (Za detalje)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var car = await _context.Car.FirstOrDefaultAsync(m => m.Id == id);
            if (car == null) return NotFound();
            return View(car);
        }

        // GET: Cars/Delete/5 (Za brisanje)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var car = await _context.Car.FirstOrDefaultAsync(m => m.Id == id);
            if (car == null) return NotFound();
            return View(car);
        }

        // POST: Cars/Delete/5 (Potvrda brisanja)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Car.FindAsync(id);
            if (car != null)
            {
                _context.Car.Remove(car);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Cars/Edit/5 (Potvrda uređivanja)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Color,ProductionYear,Price,Manufacturer")] Car car)
        {
            if (id != car.Id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Car.Any(e => e.Id == car.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }
    }
}