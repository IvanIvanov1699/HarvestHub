using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HarvestHub.Migrations
{
    /// <inheritdoc />
    public partial class addOrdersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderFull = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressFull = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    recipientFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    recipientPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    recipientEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    addressExtraInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserName",
                        column: x => x.UserName,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserName",
                table: "Orders",
                column: "UserName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
