using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EditableCV_backend.Migrations
{
    /// <inheritdoc />
    public partial class Modify_AddedSalaryToCommonInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "CommonInfos",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salary",
                table: "CommonInfos");
        }
    }
}
