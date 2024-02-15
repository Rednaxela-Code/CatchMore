using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatchMore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddingApplicationUserRelationsToSessionAndCatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Catches",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Catches_ApplicationUserId",
                table: "Catches",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Catches_AspNetUsers_ApplicationUserId",
                table: "Catches",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catches_AspNetUsers_ApplicationUserId",
                table: "Catches");

            migrationBuilder.DropIndex(
                name: "IX_Catches_ApplicationUserId",
                table: "Catches");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Catches");
        }
    }
}
