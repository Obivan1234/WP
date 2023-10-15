using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WP.API.Migrations
{
    /// <inheritdoc />
    public partial class OtherTables_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessLocationEmployee",
                columns: table => new
                {
                    BusinessLocationsBusinessLocationId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeesEmployeeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessLocationEmployee", x => new { x.BusinessLocationsBusinessLocationId, x.EmployeesEmployeeId });
                    table.ForeignKey(
                        name: "FK_BusinessLocationEmployee_BusinessLocation_BusinessLocationsBusinessLocationId",
                        column: x => x.BusinessLocationsBusinessLocationId,
                        principalTable: "BusinessLocation",
                        principalColumn: "BusinessLocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessLocationEmployee_Employee_EmployeesEmployeeId",
                        column: x => x.EmployeesEmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessLocationEmployee_EmployeesEmployeeId",
                table: "BusinessLocationEmployee",
                column: "EmployeesEmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessLocationEmployee");
        }
    }
}
