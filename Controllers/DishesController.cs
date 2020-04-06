using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dineIN.Models;
using Microsoft.AspNetCore.Authorization;


namespace dineIN.Controllers
{

    public class DishesController : Controller
    {
        private readonly DINE_INContext _context;

        public DishesController(DINE_INContext context)
        {
            _context = context;
        }

        
        // GET: Dishes
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dishes.ToListAsync());
        }

        // GET: Dishes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dishes = await _context.Dishes
                .FirstOrDefaultAsync(m => m.DishName == id);
            if (dishes == null)
            {
                return NotFound();
            }

            return View(dishes);
        }


        // GET: Dishes/Create
        
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dishes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DishId,DishName,DishDetails")] Dishes dishes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dishes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dishes);
        }

        // GET: Dishes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dishes = await _context.Dishes.FindAsync(id);
            if (dishes == null)
            {
                return NotFound();
            }
            return View(dishes);
        }

        // POST: Dishes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DishId,DishName,DishDetails")] Dishes dishes)
        {
            if (id != dishes.DishName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dishes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DishesExists(dishes.DishName))
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
            return View(dishes);
        }

        // GET: Dishes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dishes = await _context.Dishes
                .FirstOrDefaultAsync(m => m.DishName == id);
            if (dishes == null)
            {
                return NotFound();
            }

            return View(dishes);
        }

        // POST: Dishes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var dishes = await _context.Dishes.FindAsync(id);
            _context.Dishes.Remove(dishes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DishesExists(string id)
        {
            return _context.Dishes.Any(e => e.DishName == id);
        }


    }
}
