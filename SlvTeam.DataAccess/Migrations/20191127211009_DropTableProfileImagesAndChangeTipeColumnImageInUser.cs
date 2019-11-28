using Microsoft.EntityFrameworkCore.Migrations;

namespace SlvTeam.DataAccess.Migrations
{
    public partial class DropTableProfileImagesAndChangeTipeColumnImageInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                                       "ProfileImages");

            migrationBuilder.DropColumn(
                                        "ImagePath",
                                        "AspNetUsers");

            migrationBuilder.AddColumn<byte[]>(
                                               "Image",
                                               "AspNetUsers",
                                               nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                                        "Image",
                                        "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                                               "ImagePath",
                                               "AspNetUsers",
                                               "nvarchar(max)",
                                               nullable: true);

            migrationBuilder.CreateTable(
                                         "ProfileImages",
                                         table => new
                                         {
                                             Id = table.Column<int>("int")
                                                       .Annotation("SqlServer:Identity", "1, 1"),
                                             Data = table.Column<byte[]>("varbinary(max)", nullable: true),
                                             FromUserID = table.Column<string>("nvarchar(max)", nullable: true),
                                             ImageName = table.Column<string>("nvarchar(max)", nullable: true)
                                         },
                                         constraints: table => { table.PrimaryKey("PK_ProfileImages", x => x.Id); });
        }
    }
}