using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.DataAccess.Migrations
{
    public partial class DBs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_sourceofIncomes",
                table: "sourceofIncomes");

            migrationBuilder.RenameTable(
                name: "sourceofIncomes",
                newName: "SourceofIncomes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SourceofIncomes",
                table: "SourceofIncomes",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SourceofIncomes",
                table: "SourceofIncomes");

            migrationBuilder.RenameTable(
                name: "SourceofIncomes",
                newName: "sourceofIncomes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sourceofIncomes",
                table: "sourceofIncomes",
                column: "Id");
        }
    }
}
