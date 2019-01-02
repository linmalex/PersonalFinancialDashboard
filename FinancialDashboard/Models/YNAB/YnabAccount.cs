using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using FinancialDashboard.Data.Personal_Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancialDashboard.Models
{
    public class YnabAccount
    {
        #region Properties
        public string ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool On_budget { get; set; }
        public bool Closed { get; set; }
        public string Note { get; set; }
        [DataType(DataType.Currency)]
        public double Balance { get; set; }
        [DataType(DataType.Currency)]
        public double Cleared_balance { get; set; }
        [DataType(DataType.Currency)]
        public double Uncleared_balance { get; set; }
        public string Transfer_payee_id { get; set; }
        public bool Deleted { get; set; }
        [DisplayFormat(DataFormatString = "{0:P2}")] //.04 => 4% 
        public double APR { get; set; }
        //todo: add code to update this when adding a new statement
        public int MostRecentStatementID { get; set; }
        [NotMapped]
        public List<Statement> Statements { get; set; }
        public DataYnab Data { get; set; }
#endregion

        public YnabAccount() { }
        public void UpdateSelf()
        {
            PersonalData personalData = new PersonalData();
            APR = personalData.InterestRatesDictionary.Where(item => item.Key == Name).FirstOrDefault().Value;
            ID = personalData.AccountsIdDictionary.Where(x => x.Key == Name).FirstOrDefault().Value;
            Balance = Balance / 1000;
            Cleared_balance = Cleared_balance / 1000;
            Uncleared_balance = Uncleared_balance / 1000;
            Type = Extensions.SplitString(Type);
        }
    }
}



