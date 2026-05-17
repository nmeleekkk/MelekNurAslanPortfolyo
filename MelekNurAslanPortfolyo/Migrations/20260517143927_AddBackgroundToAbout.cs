using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MelekNurAslanPortfolyo.Migrations
{
    /// <inheritdoc />
    public partial class AddBackgroundToAbout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BackgroundImageUrl",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackgroundImageUrl",
                table: "Abouts");
        }
    }
}
