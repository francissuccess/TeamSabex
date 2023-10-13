using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.DataAccess.Migrations
{
    public partial class Db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sourceofIncomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Offering = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tithe = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Vow = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalesofChurchItems = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    donation = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sourceofIncomes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sourceofIncomes");
        }
    }
}
