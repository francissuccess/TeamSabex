using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.DataAccess.Migrations
{
    public partial class createdgv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Members",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Areaofspecialization",
                table: "Choirs",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Members",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Choirs",
                newName: "Areaofspecialization");
        }
    }
}
