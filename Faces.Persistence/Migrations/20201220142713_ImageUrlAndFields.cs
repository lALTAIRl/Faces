using Microsoft.EntityFrameworkCore.Migrations;

namespace Faces.Persistence.Migrations
{
    public partial class ImageUrlAndFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Images",
                newName: "ImageUrl");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Images",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sex",
                table: "Images",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Images",
                newName: "ImageURL");
        }
    }
}
