using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class login_table_updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Logins");

            migrationBuilder.AddColumn<int>(
                name: "AuthLevelRefId",
                table: "Logins",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthLevelRefId",
                table: "Logins");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Logins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
