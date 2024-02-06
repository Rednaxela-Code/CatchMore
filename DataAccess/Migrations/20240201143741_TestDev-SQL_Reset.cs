using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatchMore.DataAccess.Migrations
{
    public partial class TestDevSQL_Reset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "Date", "Latitude", "Longitude" },
                values: new object[] { 10, new DateTime(2024, 2, 1, 15, 37, 41, 149, DateTimeKind.Local).AddTicks(8772), 51.98807, 6.0045200000000003 });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "Date", "Latitude", "Longitude" },
                values: new object[] { 11, new DateTime(2024, 2, 1, 15, 37, 41, 149, DateTimeKind.Local).AddTicks(8803), 52.98807, 6.2045199999999996 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sessions");
        }
    }
}
