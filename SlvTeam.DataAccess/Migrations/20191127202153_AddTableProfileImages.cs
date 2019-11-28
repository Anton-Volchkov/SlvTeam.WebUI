using Microsoft.EntityFrameworkCore.Migrations;

namespace SlvTeam.DataAccess.Migrations
{
    public partial class AddTableProfileImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                                         "ProfileImages",
                                         table => new
                                         {
                                             Id = table.Column<int>()
                                                       .Annotation("SqlServer:Identity", "1, 1"),
                                             ImageName = table.Column<string>(nullable: true),
                                             FromUserID = table.Column<string>(nullable: true),
                                             Data = table.Column<byte[]>(nullable: true)
                                         },
                                         constraints: table => { table.PrimaryKey("PK_ProfileImages", x => x.Id); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                                       "ProfileImages");
        }
    }
}