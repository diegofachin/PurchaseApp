using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    public partial class AlterNameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apps_AppEntity_AppId",
                table: "Apps");

            migrationBuilder.DropForeignKey(
                name: "FK_Apps_Transactions_TransactionId",
                table: "Apps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Apps",
                table: "Apps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppEntity",
                table: "AppEntity");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "Transaction");

            migrationBuilder.RenameTable(
                name: "Apps",
                newName: "Purchase");

            migrationBuilder.RenameTable(
                name: "AppEntity",
                newName: "App");

            migrationBuilder.RenameIndex(
                name: "IX_Apps_TransactionId",
                table: "Purchase",
                newName: "IX_Purchase_TransactionId");

            migrationBuilder.RenameIndex(
                name: "IX_Apps_AppId",
                table: "Purchase",
                newName: "IX_Purchase_AppId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchase",
                table: "Purchase",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_App",
                table: "App",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_App_AppId",
                table: "Purchase",
                column: "AppId",
                principalTable: "App",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Transaction_TransactionId",
                table: "Purchase",
                column: "TransactionId",
                principalTable: "Transaction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_App_AppId",
                table: "Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Transaction_TransactionId",
                table: "Purchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purchase",
                table: "Purchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_App",
                table: "App");

            migrationBuilder.RenameTable(
                name: "Transaction",
                newName: "Transactions");

            migrationBuilder.RenameTable(
                name: "Purchase",
                newName: "Apps");

            migrationBuilder.RenameTable(
                name: "App",
                newName: "AppEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_TransactionId",
                table: "Apps",
                newName: "IX_Apps_TransactionId");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_AppId",
                table: "Apps",
                newName: "IX_Apps_AppId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Apps",
                table: "Apps",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppEntity",
                table: "AppEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Apps_AppEntity_AppId",
                table: "Apps",
                column: "AppId",
                principalTable: "AppEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Apps_Transactions_TransactionId",
                table: "Apps",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
