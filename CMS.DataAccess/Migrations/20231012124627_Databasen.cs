using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.DataAccess.Migrations
{
    public partial class Databasen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "sourceofIncomes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "sourceofIncomes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "sourceofIncomes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "sourceofIncomes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "sourceofIncomes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Choirs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Choirs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Choirs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Choirs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Choirs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "sourceofIncomes");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "sourceofIncomes");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "sourceofIncomes");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "sourceofIncomes");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "sourceofIncomes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Choirs");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Choirs");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Choirs");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Choirs");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Choirs");
        }
    }
}
