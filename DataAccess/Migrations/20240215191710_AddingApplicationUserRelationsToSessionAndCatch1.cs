using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatchMore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddingApplicationUserRelationsToSessionAndCatch1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Sessions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_ApplicationUserId",
                table: "Sessions",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_AspNetUsers_ApplicationUserId",
                table: "Sessions",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_AspNetUsers_ApplicationUserId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_ApplicationUserId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Sessions");
        }
    }
}
