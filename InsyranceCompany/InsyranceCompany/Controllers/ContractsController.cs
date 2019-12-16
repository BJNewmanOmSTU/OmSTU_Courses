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
    public class ContractsController : Controller
    {
        private readonly InsuranceCompanyContext _context;

        public ContractsController(InsuranceCompanyContext context)
        {
            _context = context;
        }

        // GET: Contracts
        public async Task<IActionResult> Index()
        {
            var insuranceCompanyContext = _context.Contracts.Include(c => c.Agent).Include(c => c.Client).Include(c => c.InsuranceType);
            return View(await insuranceCompanyContext.ToListAsync());
        }

        // GET: Contracts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contracts = await _context.Contracts
                .Include(c => c.Agent)
                .Include(c => c.Client)
                .Include(c => c.InsuranceType)
                .FirstOrDefaultAsync(m => m.ContractId == id);
            if (contracts == null)
            {
                return NotFound();
            }

            return View(contracts);
        }

        // GET: Contracts/Create
        public IActionResult Create()
        {
            ViewData["AgentId"] = new SelectList(_context.Agents, "AgentId", "AgentId");
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId");
            ViewData["InsuranceTypeId"] = new SelectList(_context.InsuranceType, "InsuranceTypeId", "InsuranceTypeId");
            return View();
        }

        // POST: Contracts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContractId,InsuranceTypeId,DateConclusion,Payment,AgentId,ClientId")] Contracts contracts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contracts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgentId"] = new SelectList(_context.Agents, "AgentId", "AgentId", contracts.AgentId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId", contracts.ClientId);
            ViewData["InsuranceTypeId"] = new SelectList(_context.InsuranceType, "InsuranceTypeId", "InsuranceTypeId", contracts.InsuranceTypeId);
            return View(contracts);
        }

        // GET: Contracts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contracts = await _context.Contracts.FindAsync(id);
            if (contracts == null)
            {
                return NotFound();
            }
            ViewData["AgentId"] = new SelectList(_context.Agents, "AgentId", "AgentId", contracts.AgentId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId", contracts.ClientId);
            ViewData["InsuranceTypeId"] = new SelectList(_context.InsuranceType, "InsuranceTypeId", "InsuranceTypeId", contracts.InsuranceTypeId);
            return View(contracts);
        }

        // POST: Contracts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContractId,InsuranceTypeId,DateConclusion,Payment,AgentId,ClientId")] Contracts contracts)
        {
            if (id != contracts.ContractId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contracts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractsExists(contracts.ContractId))
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
            ViewData["AgentId"] = new SelectList(_context.Agents, "AgentId", "AgentId", contracts.AgentId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId", contracts.ClientId);
            ViewData["InsuranceTypeId"] = new SelectList(_context.InsuranceType, "InsuranceTypeId", "InsuranceTypeId", contracts.InsuranceTypeId);
            return View(contracts);
        }

        // GET: Contracts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contracts = await _context.Contracts
                .Include(c => c.Agent)
                .Include(c => c.Client)
                .Include(c => c.InsuranceType)
                .FirstOrDefaultAsync(m => m.ContractId == id);
            if (contracts == null)
            {
                return NotFound();
            }

            return View(contracts);
        }

        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contracts = await _context.Contracts.FindAsync(id);
            _context.Contracts.Remove(contracts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContractsExists(int id)
        {
            return _context.Contracts.Any(e => e.ContractId == id);
        }
    }
}
