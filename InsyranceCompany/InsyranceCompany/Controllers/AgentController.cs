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
    public class AgentController : Controller
    {
        private readonly InsuranceCompanyContext _context;

        public AgentController(InsuranceCompanyContext context)
        {
            _context = context;
        }

        // GET: Agent
        public async Task<IActionResult> Index()
        {
            var insuranceCompanyContext = _context.Agents.Include(a => a.Filial);
            return View(await insuranceCompanyContext.ToListAsync());
        }

        // GET: Agent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agents = await _context.Agents
                .Include(a => a.Filial)
                .FirstOrDefaultAsync(m => m.AgentId == id);
            if (agents == null)
            {
                return NotFound();
            }

            return View(agents);
        }

        // GET: Agent/Create
        public IActionResult Create()
        {
            ViewData["FilialId"] = new SelectList(_context.Filials, "FilialId", "FilialId");
            return View();
        }

        // POST: Agent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AgentId,FilialId,AName,APatronymic,ASurname,AAddress,APhone,Salary")] Agents agents)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agents);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilialId"] = new SelectList(_context.Filials, "FilialId", "FilialId", agents.FilialId);
            return View(agents);
        }

        // GET: Agent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agents = await _context.Agents.FindAsync(id);
            if (agents == null)
            {
                return NotFound();
            }
            ViewData["FilialId"] = new SelectList(_context.Filials, "FilialId", "FilialId", agents.FilialId);
            return View(agents);
        }

        // POST: Agent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AgentId,FilialId,AName,APatronymic,ASurname,AAddress,APhone,Salary")] Agents agents)
        {
            if (id != agents.AgentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agents);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgentsExists(agents.AgentId))
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
            ViewData["FilialId"] = new SelectList(_context.Filials, "FilialId", "FilialId", agents.FilialId);
            return View(agents);
        }

        // GET: Agent/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agents = await _context.Agents
                .Include(a => a.Filial)
                .FirstOrDefaultAsync(m => m.AgentId == id);
            if (agents == null)
            {
                return NotFound();
            }

            return View(agents);
        }

        // POST: Agent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agents = await _context.Agents.FindAsync(id);
            _context.Agents.Remove(agents);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgentsExists(int id)
        {
            return _context.Agents.Any(e => e.AgentId == id);
        }
    }
}
