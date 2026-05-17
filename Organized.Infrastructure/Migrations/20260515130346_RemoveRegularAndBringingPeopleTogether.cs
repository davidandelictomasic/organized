using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Organized.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRegularAndBringingPeopleTogether : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 28);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "public",
                table: "achievements",
                columns: new[] { "id", "description", "is_hidden", "max_progress", "name", "target_role" },
                values: new object[,]
                {
                    { 2, "Make 5 reservations", false, 5, "Regular", 1 },
                    { 28, "Host meetings with 50 distinct attendees overall", false, 50, "Bringing People Together", 2 }
                });
        }
    }
}
