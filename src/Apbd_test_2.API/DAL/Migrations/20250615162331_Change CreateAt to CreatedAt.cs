using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Apbd_test_2.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCreateAttoCreatedAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "C++" },
                    { 2, "Java" },
                    { 3, "C#" }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "john.doe@gmail.com", "John", "Doe" },
                    { 2, "jane.doe@gmail.com", "Jane", "Doe" },
                    { 3, "marta.doe@gmail.com", "Marta", "Doe" }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Test preparation", "Test" },
                    { 2, "Exam preapration", "Exam" },
                    { 3, "Review preparation", "Review" }
                });

            migrationBuilder.InsertData(
                table: "Record",
                columns: new[] { "Id", "CreatedAt", "ExecutionTime", "LanguageId", "Name", "StudentId", "TaskId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 15, 18, 23, 31, 529, DateTimeKind.Local).AddTicks(1550), 11L, 1, "record 1", 1, 1 },
                    { 2, new DateTime(2025, 6, 15, 18, 23, 31, 529, DateTimeKind.Local).AddTicks(1600), 16L, 2, "record 2", 1, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Record",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Record",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
