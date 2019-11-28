using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SlvTeam.DataAccess.Migrations
{
    public partial class AddColumnImageName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageBytes",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageBytes",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "AspNetUsers",
                type: "bytea",
                nullable: true);
        }
    }
}
