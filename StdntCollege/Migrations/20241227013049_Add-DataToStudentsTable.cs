using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StdntCollege.Migrations
{
    /// <inheritdoc />
    public partial class AddDataToStudentsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Students",
                newName: "Id");

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DOB", "StudentAddress", "StudentEmail", "StudentName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Festac1", "ireolu@gmail.com", "IreOlu" },
                    { 2, new DateTime(2025, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Festac2", "ireoba@gmail.com", "IreOba" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Students",
                newName: "id");
        }
    }
}
