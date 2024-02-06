using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatchMore.DataAccess.Migrations
{
    public partial class AddedCatchModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Species = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catches", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Catches",
                columns: new[] { "Id", "Date", "Length", "Species", "Weight" },
                values: new object[,]
                {
                    { 2, new DateTime(2024, 2, 2, 10, 9, 58, 500, DateTimeKind.Local).AddTicks(4217), 50.0, "Perch", 2.0 },
                    { 3, new DateTime(2024, 2, 2, 10, 9, 58, 500, DateTimeKind.Local).AddTicks(4220), 45.0, "Perch", 1.5 }
                });

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2024, 2, 2, 10, 9, 58, 500, DateTimeKind.Local).AddTicks(4051));

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2024, 2, 2, 10, 9, 58, 500, DateTimeKind.Local).AddTicks(4082));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catches");

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2024, 2, 1, 15, 37, 41, 149, DateTimeKind.Local).AddTicks(8772));

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2024, 2, 1, 15, 37, 41, 149, DateTimeKind.Local).AddTicks(8803));
        }
    }
}
