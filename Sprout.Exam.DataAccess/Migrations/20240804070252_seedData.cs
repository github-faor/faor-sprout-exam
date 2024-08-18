using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sprout.Exam.DataAccess.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "BirthDate", "EmployeeTypeId", "FullName", "IsDeleted", "TIN" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 4, 15, 2, 51, 986, DateTimeKind.Local).AddTicks(7541), 1, "Fides Arianne Ramos", true, "1234567890" },
                    { 2, new DateTime(2024, 8, 4, 15, 2, 51, 987, DateTimeKind.Local).AddTicks(6208), 1, "Employee 2", false, "2345678901" },
                    { 3, new DateTime(2024, 8, 4, 15, 2, 51, 987, DateTimeKind.Local).AddTicks(6223), 2, "Employee 3", false, "3456789012" },
                    { 4, new DateTime(2024, 8, 4, 15, 2, 51, 987, DateTimeKind.Local).AddTicks(6225), 1, "Employee 4", false, "4567890123" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
