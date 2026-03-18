using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Organized.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "achievements",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    max_progress = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_achievements", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "company_tables",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    company_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    city = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company_tables", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "friend_requests",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sender_id = table.Column<int>(type: "integer", nullable: false),
                    receiver_id = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_friend_requests", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "friendships",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    friend_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_friendships", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "reservations",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    table_id = table.Column<int>(type: "integer", nullable: false),
                    reservation_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_achievements",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    achievement_id = table.Column<int>(type: "integer", nullable: false),
                    progress = table.Column<int>(type: "integer", nullable: false),
                    is_completed = table.Column<bool>(type: "boolean", nullable: false),
                    completed_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_achievements", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    last_online = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "achievements",
                columns: new[] { "id", "description", "max_progress", "name" },
                values: new object[,]
                {
                    { 100, "Make your first table reservation", 1, "First Reservation" },
                    { 101, "Make 5 reservations", 5, "Regular" },
                    { 102, "Make 10 reservations", 10, "Frequent Visitor" },
                    { 103, "Make 25 reservations", 25, "Power User" },
                    { 104, "Make 50 reservations", 50, "Legend" },
                    { 105, "Make a reservation before 9 AM", 1, "Early Bird" },
                    { 106, "Make a reservation after 6 PM", 1, "Night Owl" },
                    { 107, "Reserve tables at 5 different companies", 5, "Explorer" },
                    { 108, "Add 10 friends", 10, "Social Butterfly" },
                    { 109, "Add 25 friends", 25, "Networking Pro" }
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
                table: "users",
                columns: new[] { "id", "email", "last_online", "name", "password" },
                values: new object[,]
                {
                    { 100, "admin@organized.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Admin User", "admin123" },
                    { 101, "john.doe@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "John Doe", "password123" },
                    { 102, "jane.smith@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Jane Smith", "password123" },
                    { 103, "bob.johnson@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Bob Johnson", "password123" },
                    { 104, "alice.brown@example.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Alice Brown", "password123" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_friend_requests_receiver_id",
                schema: "public",
                table: "friend_requests",
                column: "receiver_id");

            migrationBuilder.CreateIndex(
                name: "IX_friend_requests_sender_id",
                schema: "public",
                table: "friend_requests",
                column: "sender_id");

            migrationBuilder.CreateIndex(
                name: "IX_friendships_friend_id",
                schema: "public",
                table: "friendships",
                column: "friend_id");

            migrationBuilder.CreateIndex(
                name: "IX_friendships_user_id",
                schema: "public",
                table: "friendships",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_friendships_user_id_friend_id",
                schema: "public",
                table: "friendships",
                columns: new[] { "user_id", "friend_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_reservations_reservation_date",
                schema: "public",
                table: "reservations",
                column: "reservation_date");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_table_id",
                schema: "public",
                table: "reservations",
                column: "table_id");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_user_id",
                schema: "public",
                table: "reservations",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_achievements_user_id",
                schema: "public",
                table: "user_achievements",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_achievements_user_id_achievement_id",
                schema: "public",
                table: "user_achievements",
                columns: new[] { "user_id", "achievement_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "achievements",
                schema: "public");

            migrationBuilder.DropTable(
                name: "company_tables",
                schema: "public");

            migrationBuilder.DropTable(
                name: "friend_requests",
                schema: "public");

            migrationBuilder.DropTable(
                name: "friendships",
                schema: "public");

            migrationBuilder.DropTable(
                name: "reservations",
                schema: "public");

            migrationBuilder.DropTable(
                name: "user_achievements",
                schema: "public");

            migrationBuilder.DropTable(
                name: "users",
                schema: "public");
        }
    }
}
