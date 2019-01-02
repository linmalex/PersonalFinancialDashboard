using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinancialDashboard.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "DataObjects",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Server_knowledge = table.Column<string>(nullable: true),
            //        DateRetrieved = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_DataObjects", x => x.ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Statuses",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Date = table.Column<DateTime>(nullable: false),
            //        CurrentMonthSpending = table.Column<double>(nullable: false),
            //        CurrentMonthIncome = table.Column<double>(nullable: false),
            //        CashOnHand = table.Column<double>(nullable: false),
            //        NetWorth = table.Column<double>(nullable: false),
            //        TotalDebt = table.Column<double>(nullable: false),
            //        TotalCCPayments = table.Column<double>(nullable: false),
            //        RetirementAccounts = table.Column<double>(nullable: false),
            //        OverallMonthlyExpenses = table.Column<double>(nullable: false),
            //        OverallMonthlyIncome = table.Column<double>(nullable: false),
            //        ThreeMonthsExpenses = table.Column<double>(nullable: false),
            //        ThreeMonthsIncome = table.Column<double>(nullable: false),
            //        ProjectedMonthlyIncome = table.Column<double>(nullable: false),
            //        Discriminator = table.Column<string>(nullable: false),
            //        NextMonthSpending = table.Column<double>(nullable: true),
            //        DebtFreeDate = table.Column<DateTime>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Statuses", x => x.ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CategoryGroups",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(nullable: false),
            //        Name = table.Column<string>(nullable: true),
            //        Hidden = table.Column<bool>(nullable: false),
            //        Deleted = table.Column<bool>(nullable: false),
            //        DataID = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CategoryGroups", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_CategoryGroups_DataObjects_DataID",
            //            column: x => x.DataID,
            //            principalTable: "DataObjects",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Transactions",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(nullable: false),
            //        Date = table.Column<DateTime>(nullable: false),
            //        Amount = table.Column<double>(nullable: false),
            //        Memo = table.Column<string>(nullable: true),
            //        Cleared = table.Column<string>(nullable: true),
            //        Approved = table.Column<bool>(nullable: false),
            //        Flag_color = table.Column<string>(nullable: true),
            //        Account_id = table.Column<string>(nullable: true),
            //        Account_name = table.Column<string>(nullable: true),
            //        Payee_id = table.Column<string>(nullable: true),
            //        Payee_name = table.Column<string>(nullable: true),
            //        Category_id = table.Column<string>(nullable: true),
            //        Category_name = table.Column<string>(nullable: true),
            //        Transfer_account_id = table.Column<string>(nullable: true),
            //        Transfer_transaction_id = table.Column<string>(nullable: true),
            //        Import_id = table.Column<string>(nullable: true),
            //        Deleted = table.Column<bool>(nullable: false),
            //        DataID = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Transactions", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Transactions_DataObjects_DataID",
            //            column: x => x.DataID,
            //            principalTable: "DataObjects",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "YnabAccounts",
            //    columns: table => new
            //    {
            //        ID = table.Column<string>(nullable: false),
            //        Name = table.Column<string>(nullable: true),
            //        Type = table.Column<string>(nullable: true),
            //        On_budget = table.Column<bool>(nullable: false),
            //        Closed = table.Column<bool>(nullable: false),
            //        Note = table.Column<string>(nullable: true),
            //        Balance = table.Column<double>(nullable: false),
            //        Cleared_balance = table.Column<double>(nullable: false),
            //        Uncleared_balance = table.Column<double>(nullable: false),
            //        Transfer_payee_id = table.Column<string>(nullable: false),
            //        Deleted = table.Column<bool>(nullable: false),
            //        APR = table.Column<double>(nullable: false),
            //        MostRecentStatementID = table.Column<int>(nullable: false),
            //        DataID = table.Column<int>(nullable: true),
            //        Discriminator = table.Column<string>(nullable: false),
            //        PayOffDate = table.Column<DateTime>(nullable: true),
            //        GoalDateMonthlyAmount = table.Column<double>(nullable: true),
            //        PayoffPriority = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_YnabAccounts", x => x.ID);
            //        table.UniqueConstraint("AK_YnabAccounts_Transfer_payee_id", x => x.Transfer_payee_id);
            //        table.ForeignKey(
            //            name: "FK_YnabAccounts_DataObjects_DataID",
            //            column: x => x.DataID,
            //            principalTable: "DataObjects",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Categories",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(nullable: false),
            //        CategoryGroupId = table.Column<string>(nullable: true),
            //        Name = table.Column<string>(nullable: true),
            //        Hidden = table.Column<bool>(nullable: false),
            //        OriginalCategoryGroupId = table.Column<string>(nullable: true),
            //        Note = table.Column<string>(nullable: true),
            //        Budgeted = table.Column<long>(nullable: false),
            //        Activity = table.Column<long>(nullable: false),
            //        Balance = table.Column<long>(nullable: false),
            //        GoalType = table.Column<string>(nullable: true),
            //        GoalCreationMonth = table.Column<DateTimeOffset>(nullable: true),
            //        GoalTarget = table.Column<long>(nullable: false),
            //        GoalTargetMonth = table.Column<DateTimeOffset>(nullable: true),
            //        GoalPercentageComplete = table.Column<long>(nullable: false),
            //        Deleted = table.Column<bool>(nullable: false),
            //        CategoryGroupId1 = table.Column<Guid>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Categories", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Categories_CategoryGroups_CategoryGroupId1",
            //            column: x => x.CategoryGroupId1,
            //            principalTable: "CategoryGroups",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Statements",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        LastStatementDate = table.Column<DateTime>(nullable: false),
            //        StatementMinPayment = table.Column<double>(nullable: false),
            //        StatementBalance = table.Column<double>(nullable: false),
            //        PaymentDueDate = table.Column<DateTime>(nullable: false),
            //        LastPaymentDate = table.Column<DateTime>(nullable: false),
            //        AutoPayScheduled = table.Column<DateTime>(nullable: false),
            //        YnabAccountID = table.Column<string>(nullable: true),
            //        AccountID = table.Column<string>(nullable: true),
            //        AccountName = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Statements", x => x.ID);
            //        table.ForeignKey(
            //            name: "FK_Statements_YnabAccounts_YnabAccountID",
            //            column: x => x.YnabAccountID,
            //            principalTable: "YnabAccounts",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Categories_CategoryGroupId1",
            //    table: "Categories",
            //    column: "CategoryGroupId1");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CategoryGroups_DataID",
            //    table: "CategoryGroups",
            //    column: "DataID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Statements_YnabAccountID",
            //    table: "Statements",
            //    column: "YnabAccountID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Transactions_DataID",
            //    table: "Transactions",
            //    column: "DataID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_YnabAccounts_DataID",
            //    table: "YnabAccounts",
            //    column: "DataID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Statements");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "CategoryGroups");

            migrationBuilder.DropTable(
                name: "YnabAccounts");

            migrationBuilder.DropTable(
                name: "DataObjects");
        }
    }
}
