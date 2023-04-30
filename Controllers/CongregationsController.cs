using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PT.Data;
using PT.Models;

namespace PT.Controllers
{
    public class CongregationsController : Controller
    {
        private readonly PTContext _context;

        public CongregationsController(PTContext context)
        {
            _context = context;
        }

        // GET: Congregations
        public async Task<IActionResult> Index()
        {
              return _context.Congregations != null ? 
                          View(await _context.Congregations.ToListAsync()) :
                          Problem("Entity set 'PTContext.Congregations'  is null.");
        }

        // GET: Congregations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Congregations == null)
            {
                return NotFound();
            }

            var congregation = await _context.Congregations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (congregation == null)
            {
                return NotFound();
            }

            return View(congregation);
        }

        // GET: Congregations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Congregations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Congregation congregation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(congregation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(congregation);
        }

        // GET: Congregations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Congregations == null)
            {
                return NotFound();
            }

            var congregation = await _context.Congregations.FindAsync(id);
            if (congregation == null)
            {
                return NotFound();
            }
            return View(congregation);
        }

        // POST: Congregations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Congregation congregation)
        {
            if (id != congregation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(congregation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CongregationExists(congregation.Id))
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
            return View(congregation);
        }

        // GET: Congregations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Congregations == null)
            {
                return NotFound();
            }

            var congregation = await _context.Congregations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (congregation == null)
            {
                return NotFound();
            }

            return View(congregation);
        }

        // POST: Congregations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Congregations == null)
            {
                return Problem("Entity set 'PTContext.Congregations'  is null.");
            }
            var congregation = await _context.Congregations.FindAsync(id);
            if (congregation != null)
            {
                _context.Congregations.Remove(congregation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CongregationExists(int id)
        {
          return (_context.Congregations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
