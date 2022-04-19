using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class login_table_updated_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthLevelRefId",
                table: "Logins");

            migrationBuilder.AddColumn<int>(
                name: "AuthId",
                table: "Logins",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuthLevelsAuthId",
                table: "Logins",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AuthLevels",
                columns: table => new
                {
                    AuthId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthName = table.Column<string>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "AuthId",
                table: "Logins");

            migrationBuilder.DropColumn(
                name: "AuthLevelsAuthId",
                table: "Logins");

            migrationBuilder.AddColumn<int>(
                name: "AuthLevelRefId",
                table: "Logins",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
