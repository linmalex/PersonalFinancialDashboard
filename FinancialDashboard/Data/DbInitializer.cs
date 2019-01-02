using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialDashboard.Models;

namespace FinancialDashboard.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            bool requestAllData = (context.Transactions.Count() == 0) ? requestAllData = true : requestAllData = false;

            DataYnab newYnabData = new DataYnab(context, requestAllData);

            //update transactions
            foreach (Transaction transaction in newYnabData.Transactions)
            {
                transaction.Data = newYnabData;
                if (context.Transactions.Contains(transaction))
                {
                    context.Transactions.Update(transaction);
                }
                else
                {
                    context.Transactions.Add(transaction);
                }
            }
            //update accounts
            foreach (YnabAccount account in newYnabData.YnabAccounts)
            {
                account.Data = newYnabData;
                if (context.YnabAccounts.Contains(account))
                {
                    context.YnabAccounts.Update(account);
                }
                else
                {
                    context.YnabAccounts.Add(account);
                }
            }

            //add category groups
            foreach (var catGroup in newYnabData.CategoryGroups)
            {
                catGroup.Data = newYnabData;
                if (context.CategoryGroups.Contains(catGroup))
                {
                    context.CategoryGroups.Update(catGroup);
                }
                else
                {
                    context.CategoryGroups.Add(catGroup);
                }
                foreach (Category category in catGroup.Categories)
                {
                    category.CategoryGroup = catGroup;
                    if (context.Categories.Contains(category))
                    {
                        context.Categories.Update(category);
                    }
                    else
                    {
                        context.Categories.Add(category);
                    }
                }
            }

            //add data object
            if (!context.DataObjects.Contains(newYnabData))
            {
                context.DataObjects.Add(newYnabData);
            }

            //save changes
            context.SaveChanges();
        }
    }

}
