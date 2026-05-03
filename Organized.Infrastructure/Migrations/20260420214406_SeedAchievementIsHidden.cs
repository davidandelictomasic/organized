using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organized.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedAchievementIsHidden : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 105,
                column: "is_hidden",
                value: true);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 106,
                column: "is_hidden",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 105,
                column: "is_hidden",
                value: false);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 106,
                column: "is_hidden",
                value: false);
        }
    }
}
