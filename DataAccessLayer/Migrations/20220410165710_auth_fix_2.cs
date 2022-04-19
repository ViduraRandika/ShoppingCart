using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class auth_fix_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logins_AuthLevels_AuthLevelsAuthId",
                table: "Logins");

            migrationBuilder.DropTable(
                name: "AuthLevels");

            migrationBuilder.DropIndex(
                name: "IX_Logins_AuthLevelsAuthId",
                table: "Logins");

            migrationBuilder.DropColumn(
                name: "AuthLevelsAuthId",
                table: "Logins");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthLevelsAuthId",
                table: "Logins",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AuthLevels",
                columns: table => new
                {
                    AuthId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthLevels", x => x.AuthId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logins_AuthLevelsAuthId",
                table: "Logins",
                column: "AuthLevelsAuthId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logins_AuthLevels_AuthLevelsAuthId",
                table: "Logins",
                column: "AuthLevelsAuthId",
                principalTable: "AuthLevels",
                principalColumn: "AuthId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
