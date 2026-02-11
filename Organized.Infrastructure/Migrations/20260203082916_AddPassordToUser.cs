using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organized.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPassordToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "password",
                schema: "public",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                schema: "public",
                table: "users");
        }
    }
}
