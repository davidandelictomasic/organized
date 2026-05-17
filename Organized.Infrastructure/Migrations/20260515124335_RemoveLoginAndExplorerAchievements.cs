using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Organized.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveLoginAndExplorerAchievements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 15);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "public",
                table: "achievements",
                columns: new[] { "id", "description", "is_hidden", "max_progress", "name", "target_role" },
                values: new object[] { 8, "Reserve tables at 5 different companies", false, 5, "Explorer", 1 });

            migrationBuilder.InsertData(
                schema: "public",
                table: "achievements",
                columns: new[] { "id", "description", "is_hidden", "max_progress", "name" },
                values: new object[,]
                {
                    { 12, "Log in 7 days", false, 7, "Just Showing Up" },
                    { 13, "Log in 30 days", false, 30, "Habit Forming" },
                    { 14, "Log in 100 days", false, 100, "Card-Carrying Member" },
                    { 15, "Log in 365 days", false, 365, "Touch Grass? Never." }
                });
        }
    }
}
