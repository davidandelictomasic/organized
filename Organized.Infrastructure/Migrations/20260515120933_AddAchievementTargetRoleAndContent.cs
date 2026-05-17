using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Organized.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAchievementTargetRoleAndContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.AddColumn<int>(
                name: "target_role",
                schema: "public",
                table: "achievements",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 1,
                column: "target_role",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 2,
                column: "target_role",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 3,
                column: "target_role",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 4,
                column: "target_role",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 5,
                column: "target_role",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 8,
                column: "target_role",
                value: 1);

            migrationBuilder.InsertData(
                schema: "public",
                table: "achievements",
                columns: new[] { "id", "description", "is_hidden", "max_progress", "name" },
                values: new object[,]
                {
                    { 11, "Add 50 friends", false, 50, "LinkedIn IRL" },
                    { 12, "Log in 7 days", false, 7, "Just Showing Up" },
                    { 13, "Log in 30 days", false, 30, "Habit Forming" },
                    { 14, "Log in 100 days", false, 100, "Card-Carrying Member" },
                    { 15, "Log in 365 days", false, 365, "Touch Grass? Never." }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "achievements",
                columns: new[] { "id", "description", "is_hidden", "max_progress", "name", "target_role" },
                values: new object[,]
                {
                    { 16, "Cancel 10 reservations", false, 10, "Plans Change", 1 },
                    { 17, "Cancel 25 reservations", false, 25, "Serial Canceller", 1 },
                    { 18, "Cancel 50 reservations", false, 50, "Master of Maybe", 1 },
                    { 19, "Create your first meeting", false, 1, "First Order of Business", 2 },
                    { 20, "Create 10 meetings", false, 10, "Meeting Maker", 2 },
                    { 21, "Create 25 meetings", false, 25, "Calendar Tetris", 2 },
                    { 22, "Create 50 meetings", false, 50, "Boss of Bosses", 2 },
                    { 23, "Cancel 5 meetings", false, 5, "Reschedule Royalty", 2 },
                    { 24, "Cancel 15 meetings", false, 15, "Master of Postponement", 2 },
                    { 25, "Get 10 meeting invite accepts", false, 10, "Popular Demand", 2 },
                    { 26, "Get 50 meeting invite accepts", false, 50, "Charisma Maxed", 2 },
                    { 27, "Schedule 25 meetings shorter than 15 minutes", false, 25, "Could've Been an Email", 2 },
                    { 28, "Host meetings with 50 distinct attendees overall", false, 50, "Bringing People Together", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 11);

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

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 28);

            migrationBuilder.DropColumn(
                name: "target_role",
                schema: "public",
                table: "achievements");

            migrationBuilder.InsertData(
                schema: "public",
                table: "achievements",
                columns: new[] { "id", "description", "is_hidden", "max_progress", "name" },
                values: new object[,]
                {
                    { 6, "Make a reservation before 9 AM", true, 1, "Early Bird" },
                    { 7, "Make a reservation after 6 PM", true, 1, "Night Owl" }
                });
        }
    }
}
