using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace librarymanagement.Migrations
{
    /// <inheritdoc />
    public partial class AddFineRecordsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "fineamount",
                table: "ReturnedBooks",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "returndate",
                table: "ReturnedBooks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "duedate",
                table: "IssuedBooks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "FineRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentid = table.Column<int>(type: "int", nullable: false),
                    bookname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fineamount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    finedate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FineRecords", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FineRecords");

            migrationBuilder.DropColumn(
                name: "fineamount",
                table: "ReturnedBooks");

            migrationBuilder.DropColumn(
                name: "returndate",
                table: "ReturnedBooks");

            migrationBuilder.DropColumn(
                name: "duedate",
                table: "IssuedBooks");
        }
    }
}
