using FinancialDashboard.Data;
using FinancialDashboard.Models;
using System.Collections.Generic;
using System.Linq;

namespace FinancialDashboard.ViewModels
{
    public class IndexViewModel
    {
        //private field
        private readonly ApplicationDbContext _context;

        //constructor
        public IndexViewModel(ApplicationDbContext context)
        {
            CurrentStatus = new Status(context);
            GoalStatus = context.Goals.Where(goal => goal.Date == context.Goals.Max(goalDate => goalDate.Date)).ToList().FirstOrDefault();
            LiabilityAccount = YnabLiabilityAccount.GetLiabilityAccountList(context);
            AssetAccount = YnabAssetAccount.SetOnBudgetAssets(context);
            _context = context;
            CurrentStatus.TotalCCPayments = CurrentStatus.GetTotalMonthlyCCPayments(LiabilityAccount);
        }

        //properties
        public Status CurrentStatus { get; set; }
        public List<YnabLiabilityAccount> LiabilityAccount { get; set; }
        public List<YnabAssetAccount> AssetAccount { get; set; }
        public GoalStatus GoalStatus { get; set; }

        //methods


        public void OnGetAsync()
        {
        }
    }
}
