using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ErpSystemFeatureDAL.Migrations
{
    /// <inheritdoc />
    public partial class intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Title = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Job = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Address = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Residance = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Mobile = table.Column<int>(type: "int", nullable: false),
                    Whatsapp = table.Column<int>(type: "int", nullable: true),
                    Nationality = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "date", nullable: true),
                    LastEdit = table.Column<DateTime>(type: "date", nullable: true),
                    CustomerRating = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Calls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CallTitle = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Project = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    EmployeeName = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    CallType = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    isDone = table.Column<bool>(type: "bit", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calls_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calls_CustomerId",
                table: "Calls",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_EmployeeId",
                table: "Customers",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calls");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
