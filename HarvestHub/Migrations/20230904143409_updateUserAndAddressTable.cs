using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HarvestHub.Migrations
{
    /// <inheritdoc />
    public partial class updateUserAndAddressTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AspNetUsers_UserName",
                table: "Addresses");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Addresses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_UserName",
                table: "Addresses",
                column: "UserName",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AspNetUsers_UserName",
                table: "Addresses");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Addresses",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_UserName",
                table: "Addresses",
                column: "UserName",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
