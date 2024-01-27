using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetPal.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class _00_initial_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:currency_code", "dkk,usd,gbp,eur");

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Code = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "MoneyAmount",
                columns: table => new
                {
                    CurrencyCode = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyAmount", x => new { x.Amount, x.CurrencyCode });
                });

            migrationBuilder.CreateTable(
                name: "Target",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Target", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Salt = table.Column<byte[]>(type: "bytea", nullable: false),
                    DateOfBirth = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Budgets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BalanceAmount = table.Column<double>(type: "double precision", nullable: false),
                    BalanceCurrencyCode = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    BudgetId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Account_MoneyAmount_BalanceAmount_BalanceCurrencyCode",
                        columns: x => new { x.BalanceAmount, x.BalanceCurrencyCode },
                        principalTable: "MoneyAmount",
                        principalColumns: new[] { "Amount", "CurrencyCode" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Account_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CategoryGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AssignedAmountAmount = table.Column<double>(type: "double precision", nullable: false),
                    AssignedAmountCurrencyCode = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    BudgetId = table.Column<Guid>(type: "uuid", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryGroup_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CategoryGroup_MoneyAmount_AssignedAmountAmount_AssignedAmou~",
                        columns: x => new { x.AssignedAmountAmount, x.AssignedAmountCurrencyCode },
                        principalTable: "MoneyAmount",
                        principalColumns: new[] { "Amount", "CurrencyCode" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TargetId = table.Column<Guid>(type: "uuid", nullable: false),
                    AssignedAmountAmount = table.Column<double>(type: "double precision", nullable: false),
                    AssignedAmountCurrencyCode = table.Column<int>(type: "integer", nullable: false),
                    CategoryGroupId = table.Column<Guid>(type: "uuid", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_CategoryGroup_CategoryGroupId",
                        column: x => x.CategoryGroupId,
                        principalTable: "CategoryGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Category_MoneyAmount_AssignedAmountAmount_AssignedAmountCur~",
                        columns: x => new { x.AssignedAmountAmount, x.AssignedAmountCurrencyCode },
                        principalTable: "MoneyAmount",
                        principalColumns: new[] { "Amount", "CurrencyCode" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Category_Target_TargetId",
                        column: x => x.TargetId,
                        principalTable: "Target",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_BalanceAmount_BalanceCurrencyCode",
                table: "Account",
                columns: new[] { "BalanceAmount", "BalanceCurrencyCode" });

            migrationBuilder.CreateIndex(
                name: "IX_Account_BudgetId",
                table: "Account",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_UserId",
                table: "Account",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_UserId",
                table: "Budgets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_AssignedAmountAmount_AssignedAmountCurrencyCode",
                table: "Category",
                columns: new[] { "AssignedAmountAmount", "AssignedAmountCurrencyCode" });

            migrationBuilder.CreateIndex(
                name: "IX_Category_CategoryGroupId",
                table: "Category",
                column: "CategoryGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_TargetId",
                table: "Category",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryGroup_AssignedAmountAmount_AssignedAmountCurrencyCo~",
                table: "CategoryGroup",
                columns: new[] { "AssignedAmountAmount", "AssignedAmountCurrencyCode" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryGroup_BudgetId",
                table: "CategoryGroup",
                column: "BudgetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "CategoryGroup");

            migrationBuilder.DropTable(
                name: "Target");

            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "MoneyAmount");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
