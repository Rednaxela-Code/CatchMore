using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatchMore.DataAccess.Migrations
{
    public partial class AddFKRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SessionId",
                table: "Catches",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Catches",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 2, 11, 18, 51, 7, 689, DateTimeKind.Local).AddTicks(8905));

            migrationBuilder.UpdateData(
                table: "Catches",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 2, 11, 18, 51, 7, 689, DateTimeKind.Local).AddTicks(8909));

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

            migrationBuilder.CreateIndex(
                name: "IX_Catches_SessionId",
                table: "Catches",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Catches_Sessions_SessionId",
                table: "Catches",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catches_Sessions_SessionId",
                table: "Catches");

            migrationBuilder.DropIndex(
                name: "IX_Catches_SessionId",
                table: "Catches");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "Catches");

            migrationBuilder.UpdateData(
                table: "Catches",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 2, 8, 18, 13, 52, 744, DateTimeKind.Local).AddTicks(286));

            migrationBuilder.UpdateData(
                table: "Catches",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 2, 8, 18, 13, 52, 744, DateTimeKind.Local).AddTicks(289));

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2024, 2, 8, 18, 13, 52, 744, DateTimeKind.Local).AddTicks(128));

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2024, 2, 8, 18, 13, 52, 744, DateTimeKind.Local).AddTicks(160));
        }
    }
}
