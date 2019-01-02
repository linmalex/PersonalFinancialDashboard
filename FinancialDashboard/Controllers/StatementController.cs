using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinancialDashboard.Data;
using FinancialDashboard.Models;
using FinancialDashboard.ViewModels;

namespace FinancialDashboard.Controllers
{
    public class StatementController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StatementController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            StatementViewModel statementViewModel = new StatementViewModel(_context, sortOrder, searchString);

            return View(statementViewModel);
        }

        // GET: Statement/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statement = await _context.Statements
                .FirstOrDefaultAsync(m => m.ID == id);
            if (statement == null)
            {
                return NotFound();
            }

            return View(statement);
        }

        // GET: Statement/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Statement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LastStatementDate,StatementMinPayment,StatementBalance,PaymentDueDate,LastPaymentDate,AutoPayScheduled,AccountID,AccountName")] Statement statement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statement);
        }

        // GET: Statement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statement = await _context.Statements.FindAsync(id);
            if (statement == null)
            {
                return NotFound();
            }
            return View(statement);
        }

        // POST: Statement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,LastStatementDate,StatementMinPayment,StatementBalance,PaymentDueDate,LastPaymentDate,AutoPayScheduled,AccountID,AccountName")] Statement statement)
        {
            if (id != statement.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatementExists(statement.ID))
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
            return View(statement);
        }

        // GET: Statement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statement = await _context.Statements
                .FirstOrDefaultAsync(m => m.ID == id);
            if (statement == null)
            {
                return NotFound();
            }

            return View(statement);
        }

        // POST: Statement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statement = await _context.Statements.FindAsync(id);
            _context.Statements.Remove(statement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatementExists(int id)
        {
            return _context.Statements.Any(e => e.ID == id);
        }
    }
}
