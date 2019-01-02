using FinancialDashboard.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialDashboard.Models
{
    public class Statement
    {
        #region properties
        #region  Statement Data
        public int ID { get; set; }
        [DataType(DataType.Date), Display(Name = "Last Statement Date")]
        public DateTime LastStatementDate { get; set; }
        [DataType(DataType.Currency), Display(Name = "Minimum Payment")]
        public double StatementMinPayment { get; set; }
        [DataType(DataType.Currency), Display(Name = "Statement Balance")]
        public double StatementBalance { get; set; }
        [DataType(DataType.Date), Display(Name = "Payment Due Date")]
        public DateTime PaymentDueDate { get; set; }
        [DataType(DataType.Date), Display(Name = "Last Payment Date")]
        public DateTime LastPaymentDate { get; set; }
        [DataType(DataType.Date), Display(Name = "Autopay scheduled date")]
        public DateTime AutoPayScheduled { get; set; }
        #endregion
        #region Other Properties
        public YnabAccount YnabAccount { get; set; }
        public string AccountID { get; set; }
        public string AccountName { get; set; }
        public bool StatementPaid { get; set; }
        #endregion
        #endregion

        public Statement()
        {
        }

        public static Statement GetMostRecentStatement(ApplicationDbContext context, string accountID)
        {
            try
            {
                List<Statement> allStatements = context.Statements.ToList();
                YnabLiabilityAccount ynabLiabilityAccount = context.LiabilityAccount.Where(x => x.ID == accountID).FirstOrDefault();
                IQueryable<Statement> allStatementsForAccount = context.Statements.Where(x => x.YnabAccount == ynabLiabilityAccount);
                DateTime lastStatementDate = allStatementsForAccount.Max(x => x.LastStatementDate);
                Statement mostRecentStatement = allStatementsForAccount.Where(x => x.LastStatementDate == lastStatementDate).FirstOrDefault();
                return mostRecentStatement;
            }
            catch
            {
                Statement mostRecentStatement = new Statement();
                return mostRecentStatement;
            }
        }
        public static List<Statement> GetOnlyNewestStatements(List<Statement> statements)
        {
            List<Statement> latestStatements = new List<Statement>();
            List<string> accountIDs = statements.Select(m => m.AccountID).Distinct().ToList();
            foreach (string item in accountIDs)
            {
                DateTime lastStatementDate = statements.Where(x => x.AccountID == item).Max(y => y.LastStatementDate);
                Statement lastStatement = statements.Where(x => x.LastStatementDate == lastStatementDate).FirstOrDefault();
                latestStatements.Add(lastStatement);
            }

            return latestStatements;
        }

    }
}
