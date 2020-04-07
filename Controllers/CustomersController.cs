using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dineIN.Models;
using Microsoft.AspNetCore.Authorization;

namespace dineIN.Controllers
{
    public class CustomersController : Controller
    {
        private readonly DINE_INContext _context;

        public CustomersController(DINE_INContext context)
        {
            _context = context;
        }

        // GET: Customers
        //To see their Favorite dish and their personal profile details
        //user should be logged in first
        //only admin can see all the customers
        
        [Authorize]
        public async Task<IActionResult> Index()
        {
            
          if (User.IsInRole("admin") || User.IsInRole("cashier"))
            {
                var dINE_INContext = _context.Customers.Include(c => c.DishNameNavigation);
                return View(await dINE_INContext.ToListAsync());
            }
            else
            {
                var dINE_INContext = _context.Customers.Include(c => c.DishNameNavigation);
                return View(await dINE_INContext.Where(x => x.Email == User.Identity.Name).ToListAsync());
            }
                
        }


    
        // GET: Customers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers
                .Include(c => c.DishNameNavigation)
                .FirstOrDefaultAsync(m => m.Email == id);
            if (customers == null)
            {
                return NotFound();
            }

            return View(customers);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewData["DishName"] = new SelectList(_context.Dishes, "DishName", "DishName");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,FirstName,LastName,Email,DishName")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DishName"] = new SelectList(_context.Dishes, "DishName", "DishName", customers.DishName);
            return View(customers);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers.FindAsync(id);
            if (customers == null)
            {
                return NotFound();
            }
            ViewData["DishName"] = new SelectList(_context.Dishes, "DishName", "DishName", customers.DishName);
            return View(customers);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CustomerId,FirstName,LastName,Email,DishName")] Customers customers)
        {
            if (id != customers.Email)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomersExists(customers.Email))
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
            ViewData["DishName"] = new SelectList(_context.Dishes, "DishName", "DishName", customers.DishName);
            return View(customers);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers
                .Include(c => c.DishNameNavigation)
                .FirstOrDefaultAsync(m => m.Email == id);
            if (customers == null)
            {
                return NotFound();
            }

            return View(customers);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var customers = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomersExists(string id)
        {
            return _context.Customers.Any(e => e.Email == id);
        }
    }
}
