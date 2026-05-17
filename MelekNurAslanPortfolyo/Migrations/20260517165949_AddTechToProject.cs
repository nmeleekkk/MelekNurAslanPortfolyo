using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MelekNurAslanPortfolyo.Migrations
{
    /// <inheritdoc />
    public partial class AddTechToProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Technologies",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Technologies",
                table: "Projects");
        }
    }
}
