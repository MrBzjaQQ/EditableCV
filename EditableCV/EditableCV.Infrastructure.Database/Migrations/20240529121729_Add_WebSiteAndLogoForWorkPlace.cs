using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EditableCV_backend.Migrations
{
    /// <inheritdoc />
    public partial class Add_WebSiteAndLogoForWorkPlace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LogoId",
                table: "WorkPlaces",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebSite",
                table: "WorkPlaces",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkPlaces_LogoId",
                table: "WorkPlaces",
                column: "LogoId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkPlaces_Files_LogoId",
                table: "WorkPlaces",
                column: "LogoId",
                principalTable: "Files",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkPlaces_Files_LogoId",
                table: "WorkPlaces");

            migrationBuilder.DropIndex(
                name: "IX_WorkPlaces_LogoId",
                table: "WorkPlaces");

            migrationBuilder.DropColumn(
                name: "LogoId",
                table: "WorkPlaces");

            migrationBuilder.DropColumn(
                name: "WebSite",
                table: "WorkPlaces");
        }
    }
}
