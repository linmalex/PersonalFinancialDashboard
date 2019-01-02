using Microsoft.EntityFrameworkCore.Migrations;

namespace FinancialDashboard.Data.Migrations
{
    public partial class AddStatementPaidStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "StatementPaid",
                table: "Statements",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatementPaid",
                table: "Statements");
        }
    }
}
