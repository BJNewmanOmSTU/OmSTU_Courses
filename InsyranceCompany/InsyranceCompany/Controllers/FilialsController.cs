using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InsyranceCompany;

namespace InsyranceCompany.Controllers
{
    public class FilialsController : Controller
    {
        private readonly InsuranceCompanyContext _context;

        public FilialsController(InsuranceCompanyContext context)
        {
            _context = context;
        }

        // GET: Filials
        public async Task<IActionResult> Index()
        {
            return View(await _context.Filials.ToListAsync());
        }

        // GET: Filials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filials = await _context.Filials
                .FirstOrDefaultAsync(m => m.FilialId == id);
            if (filials == null)
            {
                return NotFound();
            }

            return View(filials);
        }

        // GET: Filials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Filials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FilialId,FilialAddress,FilialPhone")] Filials filials)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filials);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filials);
        }

        // GET: Filials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filials = await _context.Filials.FindAsync(id);
            if (filials == null)
            {
                return NotFound();
            }
            return View(filials);
        }

        // POST: Filials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FilialId,FilialAddress,FilialPhone")] Filials filials)
        {
            if (id != filials.FilialId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filials);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilialsExists(filials.FilialId))
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
            return View(filials);
        }

        // GET: Filials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filials = await _context.Filials
                .FirstOrDefaultAsync(m => m.FilialId == id);
            if (filials == null)
            {
                return NotFound();
            }

            return View(filials);
        }

        // POST: Filials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filials = await _context.Filials.FindAsync(id);
            _context.Filials.Remove(filials);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilialsExists(int id)
        {
            return _context.Filials.Any(e => e.FilialId == id);
        }
    }
}
