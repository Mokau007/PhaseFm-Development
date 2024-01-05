using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhaseFmApi.Migrations
{
    /// <inheritdoc />
    public partial class DbColorAndSizeUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sizes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ColorCode",
                schema: "phasefm",
                table: "color",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "ColorCode",
                schema: "phasefm",
                table: "color");
        }
    }
}
