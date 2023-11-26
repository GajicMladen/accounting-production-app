using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tehnohem_api.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Unit",
                table: "InvoiceItem",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<float>(
                name: "Discount",
                table: "InvoiceItem",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Rabat",
                table: "InvoiceItem",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "SinglePriceNoPdv",
                table: "InvoiceItem",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "SinglePricePdv",
                table: "InvoiceItem",
                type: "real",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "InvoiceItem");

            migrationBuilder.DropColumn(
                name: "Rabat",
                table: "InvoiceItem");

            migrationBuilder.DropColumn(
                name: "SinglePriceNoPdv",
                table: "InvoiceItem");

            migrationBuilder.DropColumn(
                name: "SinglePricePdv",
                table: "InvoiceItem");

            migrationBuilder.AlterColumn<string>(
                name: "Unit",
                table: "InvoiceItem",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
