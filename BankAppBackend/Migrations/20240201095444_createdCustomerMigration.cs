using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankAppBackend.Migrations
{
    /// <inheritdoc />
    public partial class createdCustomerMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_applicants_tellers_TellerId",
                table: "applicants");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_applicants_ApplicantId",
                table: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tellers",
                table: "tellers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_applicants",
                table: "applicants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "tellers",
                newName: "Tellers");

            migrationBuilder.RenameTable(
                name: "applicants",
                newName: "Applicants");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameIndex(
                name: "IX_applicants_TellerId",
                table: "Applicants",
                newName: "IX_Applicants_TellerId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_ApplicantId",
                table: "Customers",
                newName: "IX_Customers_ApplicantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tellers",
                table: "Tellers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applicants",
                table: "Applicants",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Tellers_TellerId",
                table: "Applicants",
                column: "TellerId",
                principalTable: "Tellers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Applicants_ApplicantId",
                table: "Customers",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Tellers_TellerId",
                table: "Applicants");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Applicants_ApplicantId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tellers",
                table: "Tellers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applicants",
                table: "Applicants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Tellers",
                newName: "tellers");

            migrationBuilder.RenameTable(
                name: "Applicants",
                newName: "applicants");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameIndex(
                name: "IX_Applicants_TellerId",
                table: "applicants",
                newName: "IX_applicants_TellerId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_ApplicantId",
                table: "Customer",
                newName: "IX_Customer_ApplicantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tellers",
                table: "tellers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_applicants",
                table: "applicants",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_applicants_tellers_TellerId",
                table: "applicants",
                column: "TellerId",
                principalTable: "tellers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_applicants_ApplicantId",
                table: "Customer",
                column: "ApplicantId",
                principalTable: "applicants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
