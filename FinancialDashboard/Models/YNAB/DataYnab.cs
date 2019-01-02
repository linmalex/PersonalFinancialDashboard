using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FinancialDashboard.Models;
using FinancialDashboard.Data.Personal_Data;
using System.ComponentModel.DataAnnotations.Schema;
using FinancialDashboard.Models.YNAB;
using Newtonsoft.Json;
using FinancialDashboard.Data;

namespace FinancialDashboard.Models
{
    public class DataYnab
    {
        #region Properties
        public int ID { get; set; }
        public string Server_knowledge { get; set; }
        public DateTime DateRetrieved { get; set; }
        [NotMapped]
        public List<Transaction> Transactions { get; set; }
        [NotMapped]
        public List<YnabAccount> YnabAccounts { get; set; }
        [NotMapped]
        public List<CategoryGroup> CategoryGroups { get; set; }
        #endregion

        #region Constructors
        public DataYnab() { }
        ///data object to hold all new YNAB data for purposes of obtaining data at startup
        public DataYnab(ApplicationDbContext context, bool requestAllData)
        {
            string uri = requestAllData ? SetURI_AllTransactions() : SetURI_RecentTransactions(GetLastKnowledge(context.DataObjects.ToList()));
            JObject transactionsJSON = JsonObject(uri).Result;
            Server_knowledge = JsonToServerKnowledge(transactionsJSON);
            Transactions = JsonToTransactions(transactionsJSON);
            YnabAccounts = GetAccounts();
            DateRetrieved = DateTime.Now;
            CategoryGroups = GetCategoryGroups();
        }
        #endregion

        #region Methods
        #region Get Json Object
        /// <summary>
        /// Send request for JSON data to YNAB using given uri
        /// </summary>
        /// <param name="uri">Use appropriate SetURI method to determine returned JSON data</param>
        /// <returns>Returns JSON file for requested data</returns>
        public static async Task<JObject> JsonObject(string uri)
        {
            PersonalData personalData = new PersonalData();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", personalData.AuthToken);
            JObject transactionData = JObject.Parse(await client.GetStringAsync(uri));
            return transactionData;
        }
        #endregion

        #region SERVER KNOWLEDGE METHODS
        /// <summary>
        /// Parse SERVER_KNOWLEDGE value from new ynab JSON data
        /// </summary>
        /// <param name="budgetDataJSON">Obtained by calling JsonObject(uri)</param>
        /// <returns></returns>
        public static string JsonToServerKnowledge(JObject budgetDataJSON)
        {
            string serverKnowledge = budgetDataJSON["data"]["server_knowledge"].ToString();
            return serverKnowledge;
        }
        /// <summary>
        /// Get most RECENT SERVER_KNOWLEDGE value from DATABASE
        /// </summary>
        /// <param name="dataObjects">Pass in list of data objects from Database</param>
        /// <returns></returns>
        public static string GetLastKnowledge(List<DataYnab> dataObjects)
        {
            string lastKnowledge = dataObjects.Max(x => x.Server_knowledge);
            return lastKnowledge;
        }
        #endregion

        #region TRANSACTIONS
        /// <summary>
        /// Set the URI needed to obtain ALL TRANSACTIONS from Ynab
        /// </summary>
        /// <returns></returns>
        public static string SetURI_AllTransactions()
        {
            PersonalData personalData = new PersonalData();
            string uri = "https://api.youneedabudget.com/v1/budgets/" + personalData.BudgetID + "/transactions";
            return uri;
        }
        /// <summary>
        /// Set the URI needed to obtain ONLY RECENT TRANSACTIONS from Ynab
        /// </summary>
        /// <param name="lastknowledge"></param>
        /// <returns></returns>
        public static string SetURI_RecentTransactions(string lastknowledge)
        {
            PersonalData personalData = new PersonalData();
            string uri = "https://api.youneedabudget.com/v1/budgets/" + personalData.BudgetID + "/transactions" + "?last_knowledge_of_server=" + lastknowledge;
            return uri;
        }

        /// <summary>
        /// PARSES JSON file of transaction data to LIST OF TRANSACTION
        /// </summary>
        /// <param name="transactionJSON"></param>
        /// <returns></returns>
        public static List<Transaction> JsonToTransactions(JObject transactionJSON)
        {
            List<JToken> transactionsJSONTokens = transactionJSON["data"]["transactions"].Children().ToList();
            List<Transaction> newTransactions = new List<Transaction>();
            foreach (JToken jToken in transactionsJSONTokens)
            {
                var transaction = new Transaction();
                transaction = jToken.ToObject<Transaction>();
                transaction.Amount = transaction.Amount / 1000;
                newTransactions.Add(transaction);
            }
            return newTransactions;
        }

        /// <summary>
        /// Single method call request ALL TRANSACTIONS and return as list
        /// </summary>
        /// <param name="personalData"></param>
        /// <returns></returns>
        public static List<Transaction> GetTransactions()
        {
            string uri = SetURI_AllTransactions();
            JObject transactionsJSON = JsonObject(uri).Result;
            List<Transaction> transactions = JsonToTransactions(transactionsJSON);
            return transactions;
        }
        /// <summary>
        /// Single method call to request RECENT TRANSACTIONS and return as LIST
        /// </summary>
        /// <param name="personalData"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static List<Transaction> GetTransactions(string lastKnowledge)
        {
            string uri = SetURI_RecentTransactions(lastKnowledge);
            JObject transactionsJSON = JsonObject(uri).Result;
            List<Transaction> newTransactions = JsonToTransactions(transactionsJSON);
            return newTransactions;
        }
        #endregion

        #region ACCOUNTS
        /// <summary>
        /// Set URI needed to obtain ACCOUNTS INFO for specific budget ID
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public static string SetURI_Accounts()
        {
            PersonalData personalData = new PersonalData();

            string uri = "https://api.youneedabudget.com/v1/budgets/" + personalData.BudgetID + "/accounts";
            return uri;
        }
        /// <summary>
        /// PARSES JSON file to LIST OF ACCOUNTS for specific budget ID
        /// </summary>
        /// <param name="budgetResponseData"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static List<YnabAccount> JsonToAccounts(JObject budgetResponseData, ApplicationDbContext context)
        {
            List<JToken> jAccountTokens = budgetResponseData["data"]["accounts"].Children().ToList();
            List<YnabAccount> ynabAccountsList = new List<YnabAccount>();
            foreach (JToken jToken in jAccountTokens)
            {
                YnabAccount ynabAccount = jToken.ToObject<YnabAccount>();
                ynabAccount.UpdateSelf();
                if (ynabAccount.Type == "Credit Card")
                {
                    YnabLiabilityAccount newYnabAccount = new YnabLiabilityAccount(ynabAccount, context);

                    ynabAccountsList.Add(newYnabAccount);
                }
                else
                {
                    var newYnabAccount = new YnabAssetAccount(ynabAccount);
                    ynabAccountsList.Add(newYnabAccount);
                }
            }
            return ynabAccountsList;
        }
        public static List<YnabAccount> JsonToAccounts(JObject budgetResponseData)
        {
            List<JToken> jAccountTokens = budgetResponseData["data"]["accounts"].Children().ToList();
            List<YnabAccount> ynabAccountsList = new List<YnabAccount>();
            foreach (JToken jToken in jAccountTokens)
            {
                YnabAccount ynabAccount = jToken.ToObject<YnabAccount>();
                ynabAccount.UpdateSelf();
                if (ynabAccount.Type == "Credit Card")
                {
                    YnabLiabilityAccount newYnabAccount = new YnabLiabilityAccount(ynabAccount);
                    ynabAccountsList.Add(newYnabAccount);
                }
                else
                {
                    var newYnabAccount = new YnabAssetAccount(ynabAccount);
                    ynabAccountsList.Add(newYnabAccount);
                }
            }
            return ynabAccountsList;
        }

        /// <summary>
        /// Single method call issue request to YNAB for ACCOUNT DATA for specific budget return as list
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static List<YnabAccount> GetAccounts(ApplicationDbContext context)
        {
            PersonalData personalData = new PersonalData();
            string uri = SetURI_Accounts();
            JObject jsonBudgetData = JsonObject(uri).Result;
            //todo maybe it doesn't like the context here?
            List<YnabAccount> ynabAccountsList = JsonToAccounts(jsonBudgetData, context);
            return ynabAccountsList;
        }
        public static List<YnabAccount> GetAccounts()
        {
            PersonalData personalData = new PersonalData();
            string uri = SetURI_Accounts();
            JObject jsonBudgetData = JsonObject(uri).Result;
            //todo maybe it doesn't like the context here?
            List<YnabAccount> ynabAccountsList = JsonToAccounts(jsonBudgetData);
            return ynabAccountsList;
        }
        #endregion

        #region CATEGORY GROUPS
        /// <summary>
        /// Set URI needed to obtain CategoryGroups info for specific budget ID
        /// </summary>
        /// <returns></returns>
        public static string CategoryGroupsURI()
        {
            PersonalData personalData = new PersonalData();
            string uri = "https://api.youneedabudget.com/v1/budgets/" + personalData.BudgetID + "/categories";
            return uri;
        }
        /// <summary>
        /// PARSES JSON file of category data to list of Category Groups
        /// </summary>
        /// <param name="budgetDataJSON"></param>
        /// <returns></returns>
        public static List<CategoryGroup> JsonToCategoryGroups(JObject budgetDataJSON)
        {
            List<JToken> jCatGroupTokens = budgetDataJSON["data"]["category_groups"].Children().ToList();
            List<CategoryGroup> categoryGroupsList = new List<CategoryGroup>();
            foreach (JToken jToken in jCatGroupTokens)
            {
                CategoryGroup catGroup = jToken.ToObject<CategoryGroup>();
                foreach (Category category in catGroup.Categories)
                {
                    category.UpdateSelf();
                }
                categoryGroupsList.Add(catGroup);
            }
            return categoryGroupsList;
        }
        /// <summary>
        /// Single method call to request Category Group data from Ynab and return list of category groups
        /// </summary>
        /// <param name="personalData"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static List<CategoryGroup> GetCategoryGroups()
        {
            string uri = CategoryGroupsURI();
            JObject budgetDataJSON = JsonObject(uri).Result;
            List<CategoryGroup> categoryGroups = JsonToCategoryGroups(budgetDataJSON);
            return categoryGroups;
        }
        #endregion

        #endregion
    }
}