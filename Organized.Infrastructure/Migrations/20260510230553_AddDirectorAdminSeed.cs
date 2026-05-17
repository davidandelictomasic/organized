using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organized.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDirectorAdminSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "public",
                table: "users",
                columns: new[] { "id", "email", "last_online", "name", "password", "role" },
                values: new object[] { 46, "john.director@organized.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "John Director", "director123", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 46);
        }
    }
}
