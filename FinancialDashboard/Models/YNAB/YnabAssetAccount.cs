using FinancialDashboard.Data;
using FinancialDashboard.Data.Personal_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialDashboard.Models
{
    public class YnabAssetAccount : YnabAccount
    {
        public YnabAssetAccount() { }
        public YnabAssetAccount(YnabAccount ynabAccount)
        {
            PersonalData myData = new PersonalData();
            ID = ynabAccount.ID;
            Name = ynabAccount.Name;
            Balance = ynabAccount.Balance;
            Type = ynabAccount.Type;
            On_budget = ynabAccount.On_budget;
            Closed = ynabAccount.Closed;
            Note = ynabAccount.Note;
            Cleared_balance = ynabAccount.Cleared_balance;
            Uncleared_balance = ynabAccount.Cleared_balance;
            Transfer_payee_id = ynabAccount.Transfer_payee_id;
            Deleted = ynabAccount.Deleted;
            APR = ynabAccount.APR;
        }

        public static List<YnabAssetAccount> SetAssetAccounts(ApplicationDbContext context)
        {
            List<YnabAccount> newestAssetAccounts = context.YnabAccounts.Where(act => act is YnabAssetAccount).ToList();
            List<YnabAssetAccount> assets = new List<YnabAssetAccount>();
            foreach (YnabAccount item in newestAssetAccounts)
            {
                YnabAssetAccount asset = new YnabAssetAccount(item);
                assets.Add(asset);
            }
            return assets;
        }
        public static List<YnabAssetAccount> SetOnBudgetAssets(ApplicationDbContext context)
        {
            List<YnabAccount> newestAssetAccounts = context.YnabAccounts.Where(act => act is YnabAssetAccount && act.On_budget).ToList();
            List<YnabAssetAccount> assets = new List<YnabAssetAccount>();
            foreach (YnabAccount item in newestAssetAccounts)
            {
                YnabAssetAccount asset = new YnabAssetAccount(item);
                assets.Add(asset);
            }
            return assets;
        }

    }
}
