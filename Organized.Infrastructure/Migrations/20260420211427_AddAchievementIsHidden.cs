using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organized.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAchievementIsHidden : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_hidden",
                schema: "public",
                table: "achievements",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 100,
                column: "is_hidden",
                value: false);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 101,
                column: "is_hidden",
                value: false);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 102,
                column: "is_hidden",
                value: false);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 103,
                column: "is_hidden",
                value: false);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 104,
                column: "is_hidden",
                value: false);

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

            migrationBuilder.UpdateData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 107,
                column: "is_hidden",
                value: false);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 108,
                column: "is_hidden",
                value: false);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 109,
                column: "is_hidden",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_hidden",
                schema: "public",
                table: "achievements");
        }
    }
}
