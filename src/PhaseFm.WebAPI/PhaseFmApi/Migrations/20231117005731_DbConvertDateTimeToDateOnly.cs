using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhaseFmApi.Migrations
{
    /// <inheritdoc />
    public partial class DbConvertDateTimeToDateOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateGenerated",
                schema: "phasefm",
                table: "quotation",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                schema: "phasefm",
                table: "order",
                type: "date",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                schema: "phasefm",
                table: "order");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateGenerated",
                schema: "phasefm",
                table: "quotation",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
