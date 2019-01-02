using FinancialDashboard.Data.Personal_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialDashboard.Models
{
    public class GoalStatus:Status
    {
        /////////////////////////////////////////////// PROPERTIES
        [DataType(DataType.Currency), Display(Name = "Projected Spending for Next Month")]
        public double NextMonthSpending { get; set; }
        [DataType(DataType.Date), Display(Name ="Goal Debt Free Date")]
        public DateTime DebtFreeDate { get; set; }
        /////////////////////////////////////////////// CONSTRUCTORS
        public GoalStatus() { }
    }
}
