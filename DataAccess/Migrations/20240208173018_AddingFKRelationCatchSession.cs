using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatchMore.DataAccess.Migrations
{
    public partial class AddingFKRelationCatchSession : Migration
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

            migrationBuilder.CreateTable(
                name: "Catches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Species = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catches_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "Date", "Latitude", "Longitude" },
                values: new object[] { 10, new DateTime(2024, 2, 8, 18, 30, 18, 597, DateTimeKind.Local).AddTicks(9101), 51.98807, 6.0045200000000003 });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "Date", "Latitude", "Longitude" },
                values: new object[] { 11, new DateTime(2024, 2, 8, 18, 30, 18, 597, DateTimeKind.Local).AddTicks(9134), 52.98807, 6.2045199999999996 });

            migrationBuilder.InsertData(
                table: "Catches",
                columns: new[] { "Id", "Date", "Length", "SessionId", "Species", "Weight" },
                values: new object[] { 2, new DateTime(2024, 2, 8, 18, 30, 18, 597, DateTimeKind.Local).AddTicks(9252), 50.0, 10, "Perch", 2.0 });

            migrationBuilder.InsertData(
                table: "Catches",
                columns: new[] { "Id", "Date", "Length", "SessionId", "Species", "Weight" },
                values: new object[] { 3, new DateTime(2024, 2, 8, 18, 30, 18, 597, DateTimeKind.Local).AddTicks(9256), 45.0, 11, "Perch", 1.5 });

            migrationBuilder.CreateIndex(
                name: "IX_Catches_SessionId",
                table: "Catches",
                column: "SessionId");
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
