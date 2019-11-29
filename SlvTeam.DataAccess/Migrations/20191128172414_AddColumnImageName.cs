using Microsoft.EntityFrameworkCore.Migrations;

namespace SlvTeam.DataAccess.Migrations
{
    public partial class AddColumnImageName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                                        "Image",
                                        "AspNetUsers");

            migrationBuilder.AddColumn<byte[]>(
                                               "ImageBytes",
                                               "AspNetUsers",
                                               nullable: true);

            migrationBuilder.AddColumn<string>(
                                               "ImageName",
                                               "AspNetUsers",
                                               nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                                        "ImageBytes",
                                        "AspNetUsers");

            migrationBuilder.DropColumn(
                                        "ImageName",
                                        "AspNetUsers");

            migrationBuilder.AddColumn<byte[]>(
                                               "Image",
                                               "AspNetUsers",
                                               "bytea",
                                               nullable: true);
        }
    }
}