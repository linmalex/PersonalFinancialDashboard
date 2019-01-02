using FinancialDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialDashboard.Data.Personal_Data
{
    public class PersonalData
    {
        public Dictionary<string, double> InterestRatesDictionary { get; set; }
        public Dictionary<string, string> AccountsIdDictionary { get; set; }
        public Dictionary<string, PayoffPriority> PIFGoalStatus { get; set; }
        public DateTime PayOffDate { get; set; }
        public string BudgetID { get; set; }
        public string AuthToken { get; set; }
        public double Income1Expected{ get; set; }
        public double Income2Expected { get; set; }

        public GoalStatus GoalStatus { get; set; }

        public PersonalData()
        {

        }
    }
}
