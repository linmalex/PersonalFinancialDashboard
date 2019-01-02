using FinancialDashboard.Data;
using FinancialDashboard.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialDashboard.ViewModels
{
    public class StatementViewModel
    {
        private readonly ApplicationDbContext _context;

        public StatementViewModel(ApplicationDbContext context, string sortOrder, string searchString)
        {
            _context = context;
            List<Statement> statements = _context.Statements.ToList();
            statements = Models.Statement.GetOnlyNewestStatements(statements);

            statements = SetSortOrder(sortOrder, searchString, statements);

            Statement = statements;
        }

        public IList<Statement> Statement { get; set; }
        /// <summary>
        /// properties for sorting
        /// </summary>
        public string AccountNameSort { get; set; }
        public string StatementDateSort { get; set; }
        public string MinPaymentSort { get; set; }
        public string BalanceSort { get; set; }
        public string LastPaymentSort { get; set; }
        public string AutopayScheduledSort { get; set; }
        public string PaymentDueSort { get; set; }
        public string CurrentFilter { get; set; }


        public List<Statement> SetSortOrder(string sortOrder, string searchString, List<Statement> statementsList)
        {
            StatementDateSort = string.IsNullOrEmpty(sortOrder) ? "Date" : "";
            BalanceSort = sortOrder == "Balance" ? "balance_desc" : "Balance";
            AccountNameSort = sortOrder == "AccountName" ? "accountname_desc" : "AccountName";
            MinPaymentSort = sortOrder == "MinPayment" ? "minpayment_desc" : "MinPayment";
            LastPaymentSort = sortOrder == "LastPayment" ? "lastpayment_desc" : "LastPayment";
            AutopayScheduledSort = sortOrder == "AutoPayScheduled" ? "autopayscheduled_desc" : "AutoPayScheduled";
            PaymentDueSort = sortOrder == "PaymentDue" ? "paymentdue_desc" : "PaymentDue";

            CurrentFilter = searchString;
            IQueryable<Statement> statements = statementsList.AsQueryable();


            if (!string.IsNullOrEmpty(searchString))
            {
                statements = statements.Where(s => s.AccountName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Date":
                    statements = statements.OrderBy(t => t.LastStatementDate);
                    break;
                case "Balance":
                    statements = statements.OrderBy(t => t.StatementBalance);
                    break;
                case "balance_desc":
                    statements = statements.OrderByDescending(t => t.StatementBalance);
                    break;
                case "AccountName":
                    statements = statements.OrderBy(t => t.YnabAccount);
                    break;
                case "accountname_desc":
                    statements = statements.OrderByDescending(t => t.YnabAccount);
                    break;
                case "MinPayment":
                    statements = statements.OrderBy(t => t.StatementMinPayment);
                    break;
                case "minpayment_desc":
                    statements = statements.OrderByDescending(t => t.StatementMinPayment);
                    break;
                case "LastPayment":
                    statements = statements.OrderBy(t => t.LastPaymentDate);
                    break;
                case "lastpayment_desc":
                    statements = statements.OrderByDescending(t => t.LastPaymentDate);
                    break;
                case "AutoPayScheduled":
                    statements = statements.OrderBy(t => t.AutoPayScheduled);
                    break;
                case "autopayscheduled_desc":
                    statements = statements.OrderByDescending(t => t.AutoPayScheduled);
                    break;
                default:
                    statements = statements.OrderByDescending(t => t.LastStatementDate);
                    break;
            }
            return statements.ToList();
        }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            List<Statement> statements = await _context.Statements.ToListAsync();
            statements = Models.Statement.GetOnlyNewestStatements(statements);

            statements = SetSortOrder(sortOrder, searchString, statements);

            Statement = statements;
        }
    }
}
