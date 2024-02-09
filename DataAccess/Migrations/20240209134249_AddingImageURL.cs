using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatchMore.DataAccess.Migrations
{
    public partial class AddingImageURL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Catches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Catches",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "ImageUrl" },
                values: new object[] { new DateTime(2024, 2, 9, 14, 42, 48, 804, DateTimeKind.Local).AddTicks(5870), "" });

            migrationBuilder.UpdateData(
                table: "Catches",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "ImageUrl" },
                values: new object[] { new DateTime(2024, 2, 9, 14, 42, 48, 804, DateTimeKind.Local).AddTicks(5873), "" });

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2024, 2, 9, 14, 42, 48, 804, DateTimeKind.Local).AddTicks(5767));

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2024, 2, 9, 14, 42, 48, 804, DateTimeKind.Local).AddTicks(5793));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Catches");

            migrationBuilder.UpdateData(
                table: "Catches",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 2, 8, 18, 30, 18, 597, DateTimeKind.Local).AddTicks(9252));

            migrationBuilder.UpdateData(
                table: "Catches",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 2, 8, 18, 30, 18, 597, DateTimeKind.Local).AddTicks(9256));

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2024, 2, 8, 18, 30, 18, 597, DateTimeKind.Local).AddTicks(9101));

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2024, 2, 8, 18, 30, 18, 597, DateTimeKind.Local).AddTicks(9134));
        }
    }
}
