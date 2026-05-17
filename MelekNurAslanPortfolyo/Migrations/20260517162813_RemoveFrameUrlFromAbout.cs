using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MelekNurAslanPortfolyo.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFrameUrlFromAbout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FrameUrl",
                table: "Abouts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FrameUrl",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
