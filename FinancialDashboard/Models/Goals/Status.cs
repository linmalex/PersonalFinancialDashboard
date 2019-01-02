using FinancialDashboard.Data;
using FinancialDashboard.Data.Personal_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FinancialDashboard.Models
{
    public class Status
    {
        #region Properties
        public int ID { get; set; }
        #region Today
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DataType(DataType.Currency)]
        public double CurrentMonthSpending { get; set; }
        [DataType(DataType.Currency)]
        public double CurrentMonthIncome { get; set; }
        [DataType(DataType.Currency), Display(Name = "Cash on Hand")]
        public double CashOnHand { get; set; }
        [DataType(DataType.Currency), Display(Name = "Net Worth")]
        public double NetWorth { get; set; }
        [DataType(DataType.Currency), Display(Name = "Total Debt")]
        public double TotalDebt { get; set; }
        [DataType(DataType.Currency)]
        public double TotalCCPayments { get; set; }
        [DataType(DataType.Currency)]
        public double RetirementAccounts { get; set; }
        #endregion
        #region Overall Averages
        [DataType(DataType.Currency), Display(Name = "Average Monthly Expenses (Total)")]
        public double OverallMonthlyExpenses { get; set; }
        [DataType(DataType.Currency), Display(Name = "Average Monthly Income (Total)")]
        public double OverallMonthlyIncome { get; set; }
        #endregion
        #region Last Three Months
        [DataType(DataType.Currency), Display(Name = "Average Monthly Expenses (Last Three Months)")]
        public double ThreeMonthsExpenses { get; set; }
        [DataType(DataType.Currency), Display(Name = "Average Monthly Income (Last Three Months)")]
        public double ThreeMonthsIncome { get; set; }
        #endregion
        #region Projections
        [DataType(DataType.Currency), Display(Name = "Projected Income")]
        public double ProjectedMonthlyIncome { get; set; }
        #endregion
        #endregion
        #region Constructors
        public Status() { }

        public Status(ApplicationDbContext context)
        {
            PersonalData personalData = new PersonalData();
            TotalDebt = GetTotalDebt(context);
            ThreeMonthsExpenses = GetAvgMonthlyExpenses(context, 3);
            OverallMonthlyExpenses = GetAvgMonthlyExpenses(context);
            OverallMonthlyIncome = GetAverageMonthlyIncome(context);
            ThreeMonthsIncome = GetAverageMonthlyIncome(context, 3);
            CashOnHand = GetCashOnHand(context);
            NetWorth = CashOnHand + TotalDebt + RetirementAccounts;
            RetirementAccounts = GetRetirementTotals(context);
            ProjectedMonthlyIncome = personalData.Income1Expected + personalData.Income2Expected;
            CurrentMonthIncome = GetCurrentMonthIncome(context);
            CurrentMonthSpending = GetCurrentMonthSpending(context);
        }
        #endregion
        #region Methods
        public double GetCashOnHand(ApplicationDbContext context)
        {
            List<YnabAssetAccount> assets = YnabAssetAccount.SetAssetAccounts(context);
            double cashOnHand = 0;
            foreach (var item in assets)
            {
                if (item.On_budget)
                {
                    double accountBalance = item.Balance;
                    cashOnHand += accountBalance;
                }
            }
            return cashOnHand;
        }
        public double GetTotalDebt(ApplicationDbContext context)
        {
            List<YnabLiabilityAccount> liabilityAccounts = YnabLiabilityAccount.GetLiabilityAccountList(context);
            double totalDebt = 0;
            foreach (var item in liabilityAccounts)
            {
                double ccBalance = item.Balance;
                totalDebt += ccBalance;
            }
            return totalDebt;
        }
        public double GetRetirementTotals(ApplicationDbContext context)
        {
            List<YnabAssetAccount> assets = YnabAssetAccount.SetAssetAccounts(context);
            double retirementAssets = 0;
            foreach (var item in assets)
            {
                if (!item.On_budget)
                {
                    double accountBalance = item.Balance;
                    retirementAssets += accountBalance;
                }
            }
            return retirementAssets;
        }
        public double GetAvgMonthlyExpenses(ApplicationDbContext context)
        {
            List<Transaction> expenses = context.Transactions.Where(x => x.Transfer_account_id == null && x.Date.Month != 4 && x.Payee_name != "Starting Balance" && x.Category_name != "Immediate Income SubCategory").ToList();
            List<TransactionSet> monthlyData = expenses.GroupBy(o => new
            {
                o.Date.Month,
                o.Date.Year
            }).Select(g => new TransactionSet
            {
                Month = g.Key.Month,
                Year = g.Key.Year,
                Sum = g.Sum(x => x.Amount)
            }).ToList();
            int monthCount = monthlyData.Count();
            double totalExpenses = new double();
            foreach (TransactionSet set in monthlyData)
            {
                totalExpenses += set.Sum;
            }
            double averageExpenses = totalExpenses / monthCount;
            return averageExpenses;
        }
        public double GetAvgMonthlyExpenses(ApplicationDbContext context, int numMonths)
        {
            int currentMonthInt = DateTime.Now.Month;
            int twoMonthsAgo = currentMonthInt - 2;
            List<Transaction> expenses = context.Transactions.Where(x => x.Transfer_account_id == null && twoMonthsAgo <= x.Date.Month && x.Date.Month <= currentMonthInt && x.Payee_name != "Starting Balance" && x.Category_name != "Immediate Income SubCategory").ToList();
            List<TransactionSet> monthlyData = expenses.GroupBy(o => new
            {
                o.Date.Month,
                o.Date.Year
            }).Select(g => new TransactionSet
            {
                Month = g.Key.Month,
                Year = g.Key.Year,
                Sum = g.Sum(x => x.Amount)
            }).ToList();
            int monthCount = monthlyData.Count();
            double totalExpenses = new double();
            foreach (TransactionSet set in monthlyData)
            {
                totalExpenses += set.Sum;
            }
            double averageExpenses = totalExpenses / monthCount;
            return averageExpenses;
        }
        public double GetAverageMonthlyIncome(ApplicationDbContext context)
        {
            List<Transaction> incomeTransactions = context.Transactions.Where(x => x.Category_name == "Immediate Income SubCategory").ToList();
            List<TransactionSet> monthlyData = incomeTransactions.GroupBy(o => new
            {
                o.Date.Month,
                o.Date.Year
            }).Select(g => new TransactionSet
            {
                Month = g.Key.Month,
                Year = g.Key.Year,
                Sum = g.Sum(x => x.Amount)
            }).ToList();
            int monthCount = monthlyData.Count();
            double totalIncome = new double();
            foreach (TransactionSet set in monthlyData)
            {
                totalIncome += set.Sum;
            }
            double averageIncome = totalIncome / monthCount;
            return averageIncome;
        }
        public double GetAverageMonthlyIncome(ApplicationDbContext context, int numMonths)
        {
            List<Transaction> incomeTransactions = context.Transactions.Where(x => x.Category_name == "Immediate Income SubCategory" && DateTime.Now.Month - 3 <= x.Date.Month && x.Date.Month <= (DateTime.Now.Month - 1)).ToList();
            List<TransactionSet> monthlyData = incomeTransactions.GroupBy(o => new
            {
                o.Date.Month,
                o.Date.Year
            }).Select(g => new TransactionSet
            {
                Month = g.Key.Month,
                Year = g.Key.Year,
                Sum = g.Sum(x => x.Amount)
            }).ToList();
            int monthCount = monthlyData.Count();
            double totalIncome = new double();
            foreach (TransactionSet set in monthlyData)
            {
                totalIncome += set.Sum;
            }
            double averageIncome = totalIncome / monthCount;
            return averageIncome;
        }
        public double GetCurrentMonthIncome(ApplicationDbContext context)
        {
            List<Transaction> incomeTransactions = context.Transactions.Where(x => x.Category_name == "Immediate Income SubCategory" && x.Date.Month == DateTime.Now.Month).ToList();
            double totalIncome = new double();
            foreach (Transaction transaction in incomeTransactions)
            {
                totalIncome += transaction.Amount;
            }
            return totalIncome;
        }
        public double GetCurrentMonthSpending(ApplicationDbContext context)
        {
            List<Transaction> expenses = context.Transactions.Where(x => x.Transfer_account_id == null && x.Date.Month == DateTime.Now.Month && x.Payee_name != "Starting Balance" && x.Category_name != "Immediate Income SubCategory").ToList();
            double totalExpenses = new double();
            foreach (Transaction expense in expenses)
            {
                totalExpenses += expense.Amount;
            }
            return totalExpenses;
        }
        public double GetTotalMonthlyCCPayments(List<YnabLiabilityAccount> liabilityAccounts)
        {
            double totalPayments = new double();
            foreach (YnabLiabilityAccount account in liabilityAccounts)
            {
                totalPayments += account.GoalDateMonthlyAmount;
            }
            return totalPayments;
        }
        #endregion
    }
}
