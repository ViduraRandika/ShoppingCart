using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class modify_dataabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Logins_LoginUserId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropIndex(
                name: "IX_Customers_LoginUserId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LoginUserId",
                table: "Customers");

            migrationBuilder.CreateTable(
                name: "AuthLevels",
                columns: table => new
                {
                    AuthLevelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthLevelName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthLevels", x => x.AuthLevelId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    AuthLevelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_AuthLevels_AuthLevelId",
                        column: x => x.AuthLevelId,
                        principalTable: "AuthLevels",
                        principalColumn: "AuthLevelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AuthLevelId",
                table: "Users",
                column: "AuthLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_UserId",
                table: "Customers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_UserId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AuthLevels");

            migrationBuilder.DropIndex(
                name: "IX_Customers_UserId",
                table: "Customers");

            migrationBuilder.AddColumn<long>(
                name: "LoginUserId",
                table: "Customers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_LoginUserId",
                table: "Customers",
                column: "LoginUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Logins_LoginUserId",
                table: "Customers",
                column: "LoginUserId",
                principalTable: "Logins",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
