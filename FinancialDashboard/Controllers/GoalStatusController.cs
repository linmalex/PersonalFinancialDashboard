using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinancialDashboard.Data;
using FinancialDashboard.Models;

namespace FinancialDashboard.Controllers.GoalStatusController
{
    public class GoalStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GoalStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GoalStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Goals.ToListAsync());
        }

        // GET: GoalStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goalStatus = await _context.Goals
                .FirstOrDefaultAsync(m => m.ID == id);
            if (goalStatus == null)
            {
                return NotFound();
            }

            return View(goalStatus);
        }

        // GET: GoalStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GoalStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NextMonthSpending,DebtFreeDate,ID,Date,CurrentMonthSpending,CurrentMonthIncome,CashOnHand,NetWorth,TotalDebt,TotalCCPayments,RetirementAccounts,OverallMonthlyExpenses,OverallMonthlyIncome,ThreeMonthsExpenses,ThreeMonthsIncome,ProjectedMonthlyIncome")] GoalStatus goalStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(goalStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(goalStatus);
        }

        // GET: GoalStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goalStatus = await _context.Goals.FindAsync(id);
            if (goalStatus == null)
            {
                return NotFound();
            }
            return View(goalStatus);
        }

        // POST: GoalStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NextMonthSpending,DebtFreeDate,ID,Date,CurrentMonthSpending,CurrentMonthIncome,CashOnHand,NetWorth,TotalDebt,TotalCCPayments,RetirementAccounts,OverallMonthlyExpenses,OverallMonthlyIncome,ThreeMonthsExpenses,ThreeMonthsIncome,ProjectedMonthlyIncome")] GoalStatus goalStatus)
        {
            if (id != goalStatus.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goalStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoalStatusExists(goalStatus.ID))
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
            return View(goalStatus);
        }

        // GET: GoalStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goalStatus = await _context.Goals
                .FirstOrDefaultAsync(m => m.ID == id);
            if (goalStatus == null)
            {
                return NotFound();
            }

            return View(goalStatus);
        }

        // POST: GoalStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var goalStatus = await _context.Goals.FindAsync(id);
            _context.Goals.Remove(goalStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoalStatusExists(int id)
        {
            return _context.Goals.Any(e => e.ID == id);
        }
    }
}
