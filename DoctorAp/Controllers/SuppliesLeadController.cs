using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoctorAp.Data;
using DoctorAp.Models;

namespace DoctorAp.Controllers
{
    public class SuppliesLeadController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuppliesLeadController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SuppliesLead
        public async Task<IActionResult> Index()
        {
              return _context.SuppliesLead != null ? 
                          View(await _context.SuppliesLead.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.SuppliesLead'  is null.");
        }

        // GET: SuppliesLead/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.SuppliesLead == null)
            {
                return NotFound();
            }

            var suppliesLead = await _context.SuppliesLead
                .FirstOrDefaultAsync(m => m.Id == id);
            if (suppliesLead == null)
            {
                return NotFound();
            }

            return View(suppliesLead);
        }

        // GET: SuppliesLead/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SuppliesLead/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Item,Quantitiy")] SuppliesLead suppliesLead)
        {
            if (ModelState.IsValid)
            {
                _context.Add(suppliesLead);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(suppliesLead);
        }

        // GET: SuppliesLead/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.SuppliesLead == null)
            {
                return NotFound();
            }

            var suppliesLead = await _context.SuppliesLead.FindAsync(id);
            if (suppliesLead == null)
            {
                return NotFound();
            }
            return View(suppliesLead);
        }

        // POST: SuppliesLead/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Item,Quantitiy")] SuppliesLead suppliesLead)
        {
            if (id != suppliesLead.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suppliesLead);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuppliesLeadExists(suppliesLead.Id))
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
            return View(suppliesLead);
        }

        // GET: SuppliesLead/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.SuppliesLead == null)
            {
                return NotFound();
            }

            var suppliesLead = await _context.SuppliesLead
                .FirstOrDefaultAsync(m => m.Id == id);
            if (suppliesLead == null)
            {
                return NotFound();
            }

            return View(suppliesLead);
        }

        // POST: SuppliesLead/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.SuppliesLead == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SuppliesLead'  is null.");
            }
            var suppliesLead = await _context.SuppliesLead.FindAsync(id);
            if (suppliesLead != null)
            {
                _context.SuppliesLead.Remove(suppliesLead);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuppliesLeadExists(string id)
        {
          return (_context.SuppliesLead?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
