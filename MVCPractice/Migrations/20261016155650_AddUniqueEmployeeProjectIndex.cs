using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCPractice.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueEmployeeProjectIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmployeeProject_EmployeeId",
                table: "EmployeeProject");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProject_EmployeeId_ProjectId",
                table: "EmployeeProject",
                columns: new[] { "EmployeeId", "ProjectId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmployeeProject_EmployeeId_ProjectId",
                table: "EmployeeProject");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProject_EmployeeId",
                table: "EmployeeProject",
                column: "EmployeeId");
        }
    }
}
