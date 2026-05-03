using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Organized.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedFriendsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "public",
                table: "friend_requests",
                columns: new[] { "id", "created_at", "receiver_id", "sender_id", "status" },
                values: new object[] { 100, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 100, 104, 0 });

            migrationBuilder.InsertData(
                schema: "public",
                table: "friendships",
                columns: new[] { "id", "created_at", "friend_id", "user_id" },
                values: new object[,]
                {
                    { 100, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 101, 100 },
                    { 101, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 102, 100 },
                    { 102, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 103, 100 },
                    { 103, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 102, 101 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "friend_requests",
                keyColumn: "id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "friendships",
                keyColumn: "id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "friendships",
                keyColumn: "id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "friendships",
                keyColumn: "id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "friendships",
                keyColumn: "id",
                keyValue: 103);
        }
    }
}
