using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhaseFmApi.Migrations
{
    /// <inheritdoc />
    public partial class DbVatandDeliveryEntityUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Percentage",
                schema: "phasefm",
                table: "vat",
                type: "decimal(10,0)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,0)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "phasefm",
                table: "vat",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "phasefm",
                table: "delivery",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "phasefm",
                table: "vat");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "phasefm",
                table: "delivery");

            migrationBuilder.AlterColumn<decimal>(
                name: "Percentage",
                schema: "phasefm",
                table: "vat",
                type: "decimal(10,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,0)");
        }
    }
}
