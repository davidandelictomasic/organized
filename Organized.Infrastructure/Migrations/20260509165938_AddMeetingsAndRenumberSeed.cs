using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Organized.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMeetingsAndRenumberSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "friend_requests",
                keyColumn: "id",
                keyValue: 100);

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
                keyValue: 100);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 104);

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

            migrationBuilder.AddColumn<int>(
                name: "role",
                schema: "public",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "capacity",
                schema: "public",
                table: "company_tables",
                type: "integer",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<bool>(
                name: "is_meeting_room",
                schema: "public",
                table: "company_tables",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "meeting_invites",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    meeting_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    responded_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meeting_invites", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "meetings",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_by_user_id = table.Column<int>(type: "integer", nullable: false),
                    meeting_room_table_id = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    meeting_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    start_time = table.Column<TimeSpan>(type: "interval", nullable: false),
                    end_time = table.Column<TimeSpan>(type: "interval", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meetings", x => x.id);
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "achievements",
                columns: new[] { "id", "description", "is_hidden", "max_progress", "name" },
                values: new object[,]
                {
                    { 1, "Make your first table reservation", false, 1, "First Reservation" },
                    { 2, "Make 5 reservations", false, 5, "Regular" },
                    { 3, "Make 10 reservations", false, 10, "Frequent Visitor" },
                    { 4, "Make 25 reservations", false, 25, "Power User" },
                    { 5, "Make 50 reservations", false, 50, "Legend" },
                    { 6, "Make a reservation before 9 AM", true, 1, "Early Bird" },
                    { 7, "Make a reservation after 6 PM", true, 1, "Night Owl" },
                    { 8, "Reserve tables at 5 different companies", false, 5, "Explorer" },
                    { 9, "Add 10 friends", false, 10, "Social Butterfly" },
                    { 10, "Add 25 friends", false, 25, "Networking Pro" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "company_tables",
                columns: new[] { "id", "capacity", "city", "company_name" },
                values: new object[,]
                {
                    { 1, 1, "New York", "TechCorp" },
                    { 2, 1, "New York", "TechCorp" },
                    { 3, 1, "Los Angeles", "TechCorp" },
                    { 4, 1, "Chicago", "DataSoft" },
                    { 5, 1, "Chicago", "DataSoft" },
                    { 6, 1, "Seattle", "CloudBase" },
                    { 7, 1, "Seattle", "CloudBase" },
                    { 8, 1, "Austin", "InnovateLab" },
                    { 9, 1, "Austin", "InnovateLab" },
                    { 10, 1, "San Francisco", "StartupHub" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "company_tables",
                columns: new[] { "id", "capacity", "city", "company_name", "is_meeting_room" },
                values: new object[] { 11, 10, "New York", "TechCorp", true });

            migrationBuilder.InsertData(
                schema: "public",
                table: "company_tables",
                columns: new[] { "id", "capacity", "city", "company_name" },
                values: new object[,]
                {
                    { 12, 1, "New York", "TechCorp" },
                    { 13, 1, "New York", "TechCorp" },
                    { 14, 1, "New York", "TechCorp" },
                    { 15, 1, "New York", "TechCorp" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "friend_requests",
                columns: new[] { "id", "created_at", "receiver_id", "sender_id", "status" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 5, 0 },
                    { 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 9, 0 },
                    { 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 10, 0 },
                    { 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 11, 0 },
                    { 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 12, 0 }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "friendships",
                columns: new[] { "id", "created_at", "friend_id", "user_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, 1 },
                    { 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, 1 },
                    { 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4, 1 },
                    { 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, 2 },
                    { 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 6, 1 },
                    { 6, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 7, 1 },
                    { 7, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 8, 1 }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "users",
                columns: new[] { "id", "email", "last_online", "name", "password", "role" },
                values: new object[] { 1, "admin@organized.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Admin User", "admin123", 1 });

            migrationBuilder.InsertData(
                schema: "public",
                table: "users",
                columns: new[] { "id", "email", "last_online", "name", "password" },
                values: new object[,]
                {
                    { 2, "john.doe@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "John Doe", "password123" },
                    { 3, "jane.smith@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Jane Smith", "password123" },
                    { 4, "bob.johnson@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Bob Johnson", "password123" },
                    { 5, "alice.brown@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Alice Brown", "password123" },
                    { 6, "charlie.davis@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Charlie Davis", "password123" },
                    { 7, "diana.evans@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Diana Evans", "password123" },
                    { 8, "ethan.foster@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ethan Foster", "password123" },
                    { 9, "fiona.garcia@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Fiona Garcia", "password123" },
                    { 10, "george.harris@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "George Harris", "password123" },
                    { 11, "hannah.iverson@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Hannah Iverson", "password123" },
                    { 12, "ian.jackson@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ian Jackson", "password123" },
                    { 13, "julia.kim@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Julia Kim", "password123" },
                    { 14, "kevin.lee@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Kevin Lee", "password123" },
                    { 15, "laura.martinez@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Laura Martinez", "password123" },
                    { 16, "mason.nelson@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mason Nelson", "password123" },
                    { 17, "nora.oborne@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Nora Oborne", "password123" },
                    { 18, "oliver.patel@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Oliver Patel", "password123" },
                    { 19, "penelope.quinn@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Penelope Quinn", "password123" },
                    { 20, "quentin.roberts@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Quentin Roberts", "password123" },
                    { 21, "rachel.stewart@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Rachel Stewart", "password123" },
                    { 22, "samuel.thompson@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Samuel Thompson", "password123" },
                    { 23, "tara.underwood@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Tara Underwood", "password123" },
                    { 24, "uma.vasquez@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Uma Vasquez", "password123" },
                    { 25, "victor.wong@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Victor Wong", "password123" },
                    { 26, "wendy.xu@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Wendy Xu", "password123" },
                    { 27, "xavier.young@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Xavier Young", "password123" },
                    { 28, "yara.zhang@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Yara Zhang", "password123" },
                    { 29, "zachary.adams@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Zachary Adams", "password123" },
                    { 30, "amelia.brooks@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Amelia Brooks", "password123" },
                    { 31, "benjamin.carter@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Benjamin Carter", "password123" },
                    { 32, "chloe.diaz@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Chloe Diaz", "password123" },
                    { 33, "daniel.edwards@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Daniel Edwards", "password123" },
                    { 34, "emma.fischer@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Emma Fischer", "password123" },
                    { 35, "felix.green@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Felix Green", "password123" },
                    { 36, "grace.hill@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Grace Hill", "password123" },
                    { 37, "henry.ingram@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Henry Ingram", "password123" },
                    { 38, "isabella.jones@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Isabella Jones", "password123" },
                    { 39, "jacob.klein@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Jacob Klein", "password123" },
                    { 40, "katherine.lopez@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Katherine Lopez", "password123" },
                    { 41, "liam.mitchell@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Liam Mitchell", "password123" },
                    { 42, "mia.nguyen@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mia Nguyen", "password123" },
                    { 43, "noah.owens@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Noah Owens", "password123" },
                    { 44, "olivia.park@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Olivia Park", "password123" },
                    { 45, "patrick.reyes@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Patrick Reyes", "password123" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_meeting_invites_meeting_id",
                schema: "public",
                table: "meeting_invites",
                column: "meeting_id");

            migrationBuilder.CreateIndex(
                name: "IX_meeting_invites_meeting_id_user_id",
                schema: "public",
                table: "meeting_invites",
                columns: new[] { "meeting_id", "user_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_meeting_invites_user_id",
                schema: "public",
                table: "meeting_invites",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_meetings_created_by_user_id",
                schema: "public",
                table: "meetings",
                column: "created_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_meetings_meeting_date",
                schema: "public",
                table: "meetings",
                column: "meeting_date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "meeting_invites",
                schema: "public");

            migrationBuilder.DropTable(
                name: "meetings",
                schema: "public");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 5);

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

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "achievements",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "company_tables",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "friend_requests",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "friend_requests",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "friend_requests",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "friend_requests",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "friend_requests",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "friendships",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "friendships",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "friendships",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "friendships",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "friendships",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "friendships",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "friendships",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 45);

            migrationBuilder.DropColumn(
                name: "role",
                schema: "public",
                table: "users");

            migrationBuilder.DropColumn(
                name: "capacity",
                schema: "public",
                table: "company_tables");

            migrationBuilder.DropColumn(
                name: "is_meeting_room",
                schema: "public",
                table: "company_tables");

            migrationBuilder.InsertData(
                schema: "public",
                table: "achievements",
                columns: new[] { "id", "description", "is_hidden", "max_progress", "name" },
                values: new object[,]
                {
                    { 100, "Make your first table reservation", false, 1, "First Reservation" },
                    { 101, "Make 5 reservations", false, 5, "Regular" },
                    { 102, "Make 10 reservations", false, 10, "Frequent Visitor" },
                    { 103, "Make 25 reservations", false, 25, "Power User" },
                    { 104, "Make 50 reservations", false, 50, "Legend" },
                    { 105, "Make a reservation before 9 AM", true, 1, "Early Bird" },
                    { 106, "Make a reservation after 6 PM", true, 1, "Night Owl" },
                    { 107, "Reserve tables at 5 different companies", false, 5, "Explorer" },
                    { 108, "Add 10 friends", false, 10, "Social Butterfly" },
                    { 109, "Add 25 friends", false, 25, "Networking Pro" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "company_tables",
                columns: new[] { "id", "city", "company_name" },
                values: new object[,]
                {
                    { 100, "New York", "TechCorp" },
                    { 101, "New York", "TechCorp" },
                    { 102, "Los Angeles", "TechCorp" },
                    { 103, "Chicago", "DataSoft" },
                    { 104, "Chicago", "DataSoft" },
                    { 105, "Seattle", "CloudBase" },
                    { 106, "Seattle", "CloudBase" },
                    { 107, "Austin", "InnovateLab" },
                    { 108, "Austin", "InnovateLab" },
                    { 109, "San Francisco", "StartupHub" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "friend_requests",
                columns: new[] { "id", "created_at", "receiver_id", "sender_id", "status" },
                values: new object[,]
                {
                    { 100, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 100, 104, 0 },
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
                    { 100, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 101, 100 },
                    { 101, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 102, 100 },
                    { 102, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 103, 100 },
                    { 103, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 102, 101 },
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
                    { 100, "admin@organized.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Admin User", "admin123" },
                    { 101, "john.doe@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "John Doe", "password123" },
                    { 102, "jane.smith@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Jane Smith", "password123" },
                    { 103, "bob.johnson@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Bob Johnson", "password123" },
                    { 104, "alice.brown@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Alice Brown", "password123" },
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
    }
}
