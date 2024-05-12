using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EditableCV_backend.Migrations
{
    /// <inheritdoc />
    public partial class Modify_ContactInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "ContactInfos");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "ContactInfos");

            migrationBuilder.DropColumn(
                name: "LinkedIn",
                table: "ContactInfos");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "ContactInfos");

            migrationBuilder.DropColumn(
                name: "Skype",
                table: "ContactInfos");

            migrationBuilder.DropColumn(
                name: "VK",
                table: "ContactInfos");

            migrationBuilder.DropColumn(
                name: "YouTube",
                table: "ContactInfos");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ContactInfos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "ContactInfos",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ContactInfos");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "ContactInfos");

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "ContactInfos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "ContactInfos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedIn",
                table: "ContactInfos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "ContactInfos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Skype",
                table: "ContactInfos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VK",
                table: "ContactInfos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YouTube",
                table: "ContactInfos",
                type: "text",
                nullable: true);
        }
    }
}
