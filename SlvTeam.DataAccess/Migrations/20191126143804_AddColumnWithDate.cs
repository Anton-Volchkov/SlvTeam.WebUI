using Microsoft.EntityFrameworkCore.Migrations;

namespace SlvTeam.DataAccess.Migrations
{
    public partial class AddColumnWithDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                                               "TimeAnswer",
                                               "Questions",
                                               nullable: true);

            migrationBuilder.AddColumn<string>(
                                               "RegisterDate",
                                               "AspNetUsers",
                                               nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                                        "TimeAnswer",
                                        "Questions");

            migrationBuilder.DropColumn(
                                        "RegisterDate",
                                        "AspNetUsers");
        }
    }
}