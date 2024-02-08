using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatchMore.DataAccess.Migrations
{
    public partial class FirstBase : Migration
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
                table: "Catches",
                columns: new[] { "Id", "Date", "Length", "Species", "Weight" },
                values: new object[,]
                {
                    { 2, new DateTime(2024, 2, 8, 18, 13, 52, 744, DateTimeKind.Local).AddTicks(286), 50.0, "Perch", 2.0 },
                    { 3, new DateTime(2024, 2, 8, 18, 13, 52, 744, DateTimeKind.Local).AddTicks(289), 45.0, "Perch", 1.5 }
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "Date", "Latitude", "Longitude" },
                values: new object[,]
                {
                    { 10, new DateTime(2024, 2, 8, 18, 13, 52, 744, DateTimeKind.Local).AddTicks(128), 51.98807, 6.0045200000000003 },
                    { 11, new DateTime(2024, 2, 8, 18, 13, 52, 744, DateTimeKind.Local).AddTicks(160), 52.98807, 6.2045199999999996 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catches");

            migrationBuilder.DropTable(
                name: "Sessions");
        }
    }
}
