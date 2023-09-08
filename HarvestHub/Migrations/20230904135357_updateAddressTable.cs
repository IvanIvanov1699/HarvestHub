using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HarvestHub.Migrations
{
    /// <inheritdoc />
    public partial class updateAddressTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AspNetUsers_UserId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Addresses");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Addresses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserName",
                table: "Addresses",
                column: "UserName");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_UserName",
                table: "Addresses",
                column: "UserName",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AspNetUsers_UserName",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_UserName",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Addresses");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Addresses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_UserId",
                table: "Addresses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
