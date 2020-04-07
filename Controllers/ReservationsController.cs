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
    public class ReservationsController : Controller
    {
        private readonly DINE_INContext _context;

        public ReservationsController(DINE_INContext context)
        {
            _context = context;
        }


        // GET: Reservations
        //To see their Reservation
        //user should be logged in first
        //only admin and role as cashier can see all the customers
        [Authorize]
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("admin") || User.IsInRole("cashier"))
            {
                var dINE_INContext = _context.Reservations.Include(r => r.EmailNavigation);
                return View(await dINE_INContext.ToListAsync());
            }
            else
            {
                var dINE_INContext = _context.Reservations.Include(r => r.EmailNavigation);
                return View(await dINE_INContext.Where(x => x.Email == User.Identity.Name).ToListAsync());
            }

        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservations = await _context.Reservations
                .Include(r => r.EmailNavigation)
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservations == null)
            {
                return NotFound();
            }

            return View(reservations);
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            ViewData["Email"] = new SelectList(_context.Customers, "Email", "Email");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservationId,Date,Email,Table")] Reservations reservations)
        {

            if (ModelState.IsValid)
            {
                _context.Add(reservations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Email"] = new SelectList(_context.Customers, "Email", "Email", reservations.Email);
            return View(reservations);
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservations = await _context.Reservations.FindAsync(id);
            if (reservations == null)
            {
                return NotFound();
            }
            ViewData["Email"] = new SelectList(_context.Customers, "Email", "Email", reservations.Email);
            return View(reservations);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservationId,Date,Email,Table")] Reservations reservations)
        {
            if (id != reservations.ReservationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationsExists(reservations.ReservationId))
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
            ViewData["Email"] = new SelectList(_context.Customers, "Email", "Email", reservations.Email);
            return View(reservations);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservations = await _context.Reservations
                .Include(r => r.EmailNavigation)
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservations == null)
            {
                return NotFound();
            }

            return View(reservations);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservations = await _context.Reservations.FindAsync(id);
            _context.Reservations.Remove(reservations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationsExists(int id)
        {
            return _context.Reservations.Any(e => e.ReservationId == id);
        }
    }
}
