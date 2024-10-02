using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RhythmHaven.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddAccountField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Account",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnsignName",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Account",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "UnsignName",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Account");
        }
    }
}
