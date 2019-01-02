using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinancialDashboard.Data;
using FinancialDashboard.Models;

namespace FinancialDashboard.Controllers
{
    public class YnabAccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public YnabAccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: YnabAccount
        public async Task<IActionResult> Index()
        {
            return View(await _context.YnabAccounts.ToListAsync());
        }

        // GET: YnabAccount/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ynabAccount = await _context.YnabAccounts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ynabAccount == null)
            {
                return NotFound();
            }

            return View(ynabAccount);
        }

        // GET: YnabAccount/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: YnabAccount/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Type,On_budget,Closed,Note,Balance,Cleared_balance,Uncleared_balance,Transfer_payee_id,Deleted,APR,MostRecentStatementID")] YnabAccount ynabAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ynabAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ynabAccount);
        }

        // GET: YnabAccount/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ynabAccount = await _context.YnabAccounts.FindAsync(id);
            if (ynabAccount == null)
            {
                return NotFound();
            }
            return View(ynabAccount);
        }

        // POST: YnabAccount/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Name,Type,On_budget,Closed,Note,Balance,Cleared_balance,Uncleared_balance,Transfer_payee_id,Deleted,APR,MostRecentStatementID")] YnabAccount ynabAccount)
        {
            if (id != ynabAccount.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ynabAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YnabAccountExists(ynabAccount.ID))
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
            return View(ynabAccount);
        }

        // GET: YnabAccount/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ynabAccount = await _context.YnabAccounts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ynabAccount == null)
            {
                return NotFound();
            }

            return View(ynabAccount);
        }

        // POST: YnabAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var ynabAccount = await _context.YnabAccounts.FindAsync(id);
            _context.YnabAccounts.Remove(ynabAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YnabAccountExists(string id)
        {
            return _context.YnabAccounts.Any(e => e.ID == id);
        }
    }
}
