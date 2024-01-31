using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankAppBackend.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tellers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tellers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "applicants",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dob = table.Column<DateOnly>(type: "date", nullable: false),
                    accountType = table.Column<int>(type: "int", nullable: false),
                    accountStatus = table.Column<int>(type: "int", nullable: false),
                    TellerId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_applicants_tellers_TellerId",
                        column: x => x.TellerId,
                        principalTable: "tellers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_applicants_TellerId",
                table: "applicants",
                column: "TellerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "applicants");

            migrationBuilder.DropTable(
                name: "tellers");
        }
    }
}
