using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WP.API.Migrations
{
    /// <inheritdoc />
    public partial class OtherTables_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessLocation_Customers_CustomerId",
                table: "BusinessLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessLocationEmployee_BusinessLocation_BusinessLocationsBusinessLocationId",
                table: "BusinessLocationEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessLocationEmployee_Employee_EmployeesEmployeeId",
                table: "BusinessLocationEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerEmployee_Employee_EmployeesEmployeeId",
                table: "CustomerEmployee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusinessLocation",
                table: "BusinessLocation");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "BusinessLocation",
                newName: "BusinessLocations");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessLocation_CustomerId",
                table: "BusinessLocations",
                newName: "IX_BusinessLocations_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusinessLocations",
                table: "BusinessLocations",
                column: "BusinessLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessLocationEmployee_BusinessLocations_BusinessLocationsBusinessLocationId",
                table: "BusinessLocationEmployee",
                column: "BusinessLocationsBusinessLocationId",
                principalTable: "BusinessLocations",
                principalColumn: "BusinessLocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessLocationEmployee_Employees_EmployeesEmployeeId",
                table: "BusinessLocationEmployee",
                column: "EmployeesEmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessLocations_Customers_CustomerId",
                table: "BusinessLocations",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerEmployee_Employees_EmployeesEmployeeId",
                table: "CustomerEmployee",
                column: "EmployeesEmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessLocationEmployee_BusinessLocations_BusinessLocationsBusinessLocationId",
                table: "BusinessLocationEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessLocationEmployee_Employees_EmployeesEmployeeId",
                table: "BusinessLocationEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessLocations_Customers_CustomerId",
                table: "BusinessLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerEmployee_Employees_EmployeesEmployeeId",
                table: "CustomerEmployee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusinessLocations",
                table: "BusinessLocations");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameTable(
                name: "BusinessLocations",
                newName: "BusinessLocation");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessLocations_CustomerId",
                table: "BusinessLocation",
                newName: "IX_BusinessLocation_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusinessLocation",
                table: "BusinessLocation",
                column: "BusinessLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessLocation_Customers_CustomerId",
                table: "BusinessLocation",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessLocationEmployee_BusinessLocation_BusinessLocationsBusinessLocationId",
                table: "BusinessLocationEmployee",
                column: "BusinessLocationsBusinessLocationId",
                principalTable: "BusinessLocation",
                principalColumn: "BusinessLocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessLocationEmployee_Employee_EmployeesEmployeeId",
                table: "BusinessLocationEmployee",
                column: "EmployeesEmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerEmployee_Employee_EmployeesEmployeeId",
                table: "CustomerEmployee",
                column: "EmployeesEmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
