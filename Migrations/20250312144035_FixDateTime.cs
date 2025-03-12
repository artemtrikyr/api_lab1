using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api_lab1.Migrations
{
    /// <inheritdoc />
    public partial class FixDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AttendanceRecords",
                columns: new[] { "Id", "Discipline", "Group", "LessonDate", "Student", "Teacher", "WasPresent" },
                values: new object[,]
                {
                    { 1, "Mathematics", "CS101", new DateTime(2024, 4, 1, 9, 0, 0, 0, DateTimeKind.Utc), "John Doe", "Dr. Smith", true },
                    { 2, "Physics", "CS102", new DateTime(2025, 3, 1, 9, 0, 0, 0, DateTimeKind.Utc), "Jane Smith", "Dr. Brown", false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
