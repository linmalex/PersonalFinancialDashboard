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
    public class YnabLiabilityAccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public YnabLiabilityAccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: YnabLiabilityAccount
        public async Task<IActionResult> Index()
        {
            return View(await _context.LiabilityAccount.ToListAsync());
        }

        // GET: YnabLiabilityAccount/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ynabLiabilityAccount = await _context.LiabilityAccount
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ynabLiabilityAccount == null)
            {
                return NotFound();
            }

            return View(ynabLiabilityAccount);
        }

        // GET: YnabLiabilityAccount/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: YnabLiabilityAccount/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PayOffDate,GoalDateMonthlyAmount,PayoffPriority,ID,Name,Type,On_budget,Closed,Note,Balance,Cleared_balance,Uncleared_balance,Transfer_payee_id,Deleted,APR,MostRecentStatementID")] YnabLiabilityAccount ynabLiabilityAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ynabLiabilityAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ynabLiabilityAccount);
        }

        // GET: YnabLiabilityAccount/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ynabLiabilityAccount = await _context.LiabilityAccount.FindAsync(id);
            if (ynabLiabilityAccount == null)
            {
                return NotFound();
            }
            return View(ynabLiabilityAccount);
        }

        // POST: YnabLiabilityAccount/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PayOffDate,GoalDateMonthlyAmount,PayoffPriority,ID,Name,Type,On_budget,Closed,Note,Balance,Cleared_balance,Uncleared_balance,Transfer_payee_id,Deleted,APR,MostRecentStatementID")] YnabLiabilityAccount ynabLiabilityAccount)
        {
            if (id != ynabLiabilityAccount.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ynabLiabilityAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YnabLiabilityAccountExists(ynabLiabilityAccount.ID))
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
            return View(ynabLiabilityAccount);
        }

        // GET: YnabLiabilityAccount/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ynabLiabilityAccount = await _context.LiabilityAccount
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ynabLiabilityAccount == null)
            {
                return NotFound();
            }

            return View(ynabLiabilityAccount);
        }

        // POST: YnabLiabilityAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var ynabLiabilityAccount = await _context.LiabilityAccount.FindAsync(id);
            _context.LiabilityAccount.Remove(ynabLiabilityAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YnabLiabilityAccountExists(string id)
        {
            return _context.LiabilityAccount.Any(e => e.ID == id);
        }
    }
}
