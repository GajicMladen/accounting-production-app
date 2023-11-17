using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tehnohem_api.Migrations
{
    /// <inheritdoc />
    public partial class changedTotalValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Raws",
                newName: "TotalValue");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Products",
                newName: "TotalValue");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Invoices",
                newName: "TotalValueWithoutPDV");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "InvoiceItem",
                newName: "TotalValueWithoutPDV");

            migrationBuilder.AddColumn<float>(
                name: "TotalValue",
                table: "Invoices",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TotalValueOfPDV",
                table: "Invoices",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TotalValue",
                table: "InvoiceItem",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TotalValueOfPDV",
                table: "InvoiceItem",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalValue",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "TotalValueOfPDV",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "TotalValue",
                table: "InvoiceItem");

            migrationBuilder.DropColumn(
                name: "TotalValueOfPDV",
                table: "InvoiceItem");

            migrationBuilder.RenameColumn(
                name: "TotalValue",
                table: "Raws",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "TotalValue",
                table: "Products",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "TotalValueWithoutPDV",
                table: "Invoices",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "TotalValueWithoutPDV",
                table: "InvoiceItem",
                newName: "TotalPrice");
        }
    }
}
