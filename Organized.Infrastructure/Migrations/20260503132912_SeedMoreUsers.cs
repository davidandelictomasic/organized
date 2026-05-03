using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Organized.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoreUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "public",
                table: "friend_requests",
                columns: new[] { "id", "created_at", "receiver_id", "sender_id", "status" },
                values: new object[,]
                {
                    { 101, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 100, 108, 0 },
                    { 102, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 100, 109, 0 },
                    { 103, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 100, 110, 0 },
                    { 104, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 100, 111, 0 }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "friendships",
                columns: new[] { "id", "created_at", "friend_id", "user_id" },
                values: new object[,]
                {
                    { 104, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 105, 100 },
                    { 105, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 106, 100 },
                    { 106, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 107, 100 }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "users",
                columns: new[] { "id", "email", "last_online", "name", "password" },
                values: new object[,]
                {
                    { 105, "charlie.davis@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Charlie Davis", "password123" },
                    { 106, "diana.evans@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Diana Evans", "password123" },
                    { 107, "ethan.foster@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ethan Foster", "password123" },
                    { 108, "fiona.garcia@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Fiona Garcia", "password123" },
                    { 109, "george.harris@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "George Harris", "password123" },
                    { 110, "hannah.iverson@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Hannah Iverson", "password123" },
                    { 111, "ian.jackson@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ian Jackson", "password123" },
                    { 112, "julia.kim@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Julia Kim", "password123" },
                    { 113, "kevin.lee@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Kevin Lee", "password123" },
                    { 114, "laura.martinez@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Laura Martinez", "password123" },
                    { 115, "mason.nelson@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mason Nelson", "password123" },
                    { 116, "nora.oborne@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Nora Oborne", "password123" },
                    { 117, "oliver.patel@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Oliver Patel", "password123" },
                    { 118, "penelope.quinn@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Penelope Quinn", "password123" },
                    { 119, "quentin.roberts@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Quentin Roberts", "password123" },
                    { 120, "rachel.stewart@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Rachel Stewart", "password123" },
                    { 121, "samuel.thompson@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Samuel Thompson", "password123" },
                    { 122, "tara.underwood@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Tara Underwood", "password123" },
                    { 123, "uma.vasquez@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Uma Vasquez", "password123" },
                    { 124, "victor.wong@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Victor Wong", "password123" },
                    { 125, "wendy.xu@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Wendy Xu", "password123" },
                    { 126, "xavier.young@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Xavier Young", "password123" },
                    { 127, "yara.zhang@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Yara Zhang", "password123" },
                    { 128, "zachary.adams@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Zachary Adams", "password123" },
                    { 129, "amelia.brooks@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Amelia Brooks", "password123" },
                    { 130, "benjamin.carter@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Benjamin Carter", "password123" },
                    { 131, "chloe.diaz@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Chloe Diaz", "password123" },
                    { 132, "daniel.edwards@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Daniel Edwards", "password123" },
                    { 133, "emma.fischer@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Emma Fischer", "password123" },
                    { 134, "felix.green@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Felix Green", "password123" },
                    { 135, "grace.hill@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Grace Hill", "password123" },
                    { 136, "henry.ingram@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Henry Ingram", "password123" },
                    { 137, "isabella.jones@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Isabella Jones", "password123" },
                    { 138, "jacob.klein@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Jacob Klein", "password123" },
                    { 139, "katherine.lopez@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Katherine Lopez", "password123" },
                    { 140, "liam.mitchell@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Liam Mitchell", "password123" },
                    { 141, "mia.nguyen@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mia Nguyen", "password123" },
                    { 142, "noah.owens@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Noah Owens", "password123" },
                    { 143, "olivia.park@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Olivia Park", "password123" },
                    { 144, "patrick.reyes@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Patrick Reyes", "password123" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "friend_requests",
                keyColumn: "id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "friend_requests",
                keyColumn: "id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "friend_requests",
                keyColumn: "id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "friend_requests",
                keyColumn: "id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "friendships",
                keyColumn: "id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "friendships",
                keyColumn: "id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "friendships",
                keyColumn: "id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 144);
        }
    }
}
