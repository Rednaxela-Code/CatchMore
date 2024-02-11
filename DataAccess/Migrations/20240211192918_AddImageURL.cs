using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatchMore.DataAccess.Migrations
{
    public partial class AddImageURL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Catches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Catches",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Image", "SessionId" },
                values: new object[] { new DateTime(2024, 2, 11, 20, 29, 17, 833, DateTimeKind.Local).AddTicks(2637), "", 10 });

            migrationBuilder.UpdateData(
                table: "Catches",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Image", "SessionId" },
                values: new object[] { new DateTime(2024, 2, 11, 20, 29, 17, 833, DateTimeKind.Local).AddTicks(2640), "", 11 });

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2024, 2, 11, 20, 29, 17, 833, DateTimeKind.Local).AddTicks(2532));

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2024, 2, 11, 20, 29, 17, 833, DateTimeKind.Local).AddTicks(2565));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Catches");

            migrationBuilder.UpdateData(
                table: "Catches",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "SessionId" },
                values: new object[] { new DateTime(2024, 2, 11, 18, 51, 7, 689, DateTimeKind.Local).AddTicks(8905), null });

            migrationBuilder.UpdateData(
                table: "Catches",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "SessionId" },
                values: new object[] { new DateTime(2024, 2, 11, 18, 51, 7, 689, DateTimeKind.Local).AddTicks(8909), null });

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2024, 2, 11, 18, 51, 7, 689, DateTimeKind.Local).AddTicks(8796));

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2024, 2, 11, 18, 51, 7, 689, DateTimeKind.Local).AddTicks(8826));
        }
    }
}
