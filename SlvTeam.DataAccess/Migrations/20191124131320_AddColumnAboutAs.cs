using Microsoft.EntityFrameworkCore.Migrations;

namespace SlvTeam.DataAccess.Migrations
{
    public partial class AddColumnAboutAs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutAs",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutAs",
                table: "AspNetUsers");
        }
    }
}
