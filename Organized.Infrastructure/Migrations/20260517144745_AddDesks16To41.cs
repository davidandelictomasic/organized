using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Organized.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDesks16To41 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "public",
                table: "company_tables",
                columns: new[] { "id", "capacity", "city", "company_name" },
                values: new object[,]
                {
                    { 16, 1, "New York", "TechCorp" },
                    { 17, 1, "New York", "TechCorp" },
                    { 18, 1, "New York", "TechCorp" },
                    { 19, 1, "New York", "TechCorp" },
                    { 20, 1, "New York", "TechCorp" },
                    { 21, 1, "New York", "TechCorp" },
                    { 22, 1, "New York", "TechCorp" },
                    { 23, 1, "New York", "TechCorp" },
                    { 24, 1, "New York", "TechCorp" },
                    { 25, 1, "New York", "TechCorp" },
                    { 26, 1, "New York", "TechCorp" },
                    { 27, 1, "New York", "TechCorp" },
                    { 28, 1, "New York", "TechCorp" },
                    { 29, 1, "New York", "TechCorp" },
                    { 30, 1, "New York", "TechCorp" },
                    { 31, 1, "New York", "TechCorp" },
                    { 32, 1, "New York", "TechCorp" },
                    { 33, 1, "New York", "TechCorp" },
                    { 34, 1, "New York", "TechCorp" },
                    { 35, 1, "New York", "TechCorp" },
                    { 36, 1, "New York", "TechCorp" },
                    { 37, 1, "New York", "TechCorp" },
                    { 38, 1, "New York", "TechCorp" },
                    { 39, 1, "New York", "TechCorp" },
                    { 40, 1, "New York", "TechCorp" },
                    { 41, 1, "New York", "TechCorp" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 41);
        }
    }
}
