using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCPractice.Migrations
{
    /// <inheritdoc />
    public partial class updateEmployeeAndDepartmentAndProjectTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Project");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Department",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Project",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2027, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Project",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employee",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Employee",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "Default Address");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Email@gmail.com");

            migrationBuilder.AddColumn<DateTime>(
                name: "HireDate",
                table: "Employee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Default Phone");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Department",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Default Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "HireDate",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Department");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Department",
                newName: "id");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "Project",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
