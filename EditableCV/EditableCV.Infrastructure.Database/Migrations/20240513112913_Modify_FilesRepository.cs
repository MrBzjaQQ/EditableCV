using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EditableCV_backend.Migrations
{
    /// <inheritdoc />
    public partial class Modify_FilesRepository : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommonInfos_Images_PhotoId",
                table: "CommonInfos");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Images",
                newName: "FileName");

            migrationBuilder.RenameColumn(
                name: "PhotoId",
                table: "CommonInfos",
                newName: "FileId");

            migrationBuilder.RenameIndex(
                name: "IX_CommonInfos_PhotoId",
                table: "CommonInfos",
                newName: "IX_CommonInfos_FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommonInfos_Images_FileId",
                table: "CommonInfos",
                column: "FileId",
                principalTable: "Images",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommonInfos_Images_FileId",
                table: "CommonInfos");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Images",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FileId",
                table: "CommonInfos",
                newName: "PhotoId");

            migrationBuilder.RenameIndex(
                name: "IX_CommonInfos_FileId",
                table: "CommonInfos",
                newName: "IX_CommonInfos_PhotoId");

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "Images",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddForeignKey(
                name: "FK_CommonInfos_Images_PhotoId",
                table: "CommonInfos",
                column: "PhotoId",
                principalTable: "Images",
                principalColumn: "Id");
        }
    }
}
