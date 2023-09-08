using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HarvestHub.Migrations
{
    /// <inheritdoc />
    public partial class updateOrderTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_AspNetUsers_UserId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Items_ItemId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_ItemId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_UserId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Added",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "isSold",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "recipientPhoneNumber",
                table: "Orders",
                newName: "RecipientPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "recipientFullName",
                table: "Orders",
                newName: "RecipientFullName");

            migrationBuilder.RenameColumn(
                name: "recipientEmail",
                table: "Orders",
                newName: "RecipientEmail");

            migrationBuilder.RenameColumn(
                name: "addressExtraInfo",
                table: "Orders",
                newName: "AddressExtraInfo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RecipientPhoneNumber",
                table: "Orders",
                newName: "recipientPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "RecipientFullName",
                table: "Orders",
                newName: "recipientFullName");

            migrationBuilder.RenameColumn(
                name: "RecipientEmail",
                table: "Orders",
                newName: "recipientEmail");

            migrationBuilder.RenameColumn(
                name: "AddressExtraInfo",
                table: "Orders",
                newName: "addressExtraInfo");

            migrationBuilder.AddColumn<DateTime>(
                name: "Added",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CartItems",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "isSold",
                table: "CartItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ItemId",
                table: "CartItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_UserId",
                table: "CartItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_AspNetUsers_UserId",
                table: "CartItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Items_ItemId",
                table: "CartItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
