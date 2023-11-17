using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tehnohem_api.Migrations
{
    /// <inheritdoc />
    public partial class pdvColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Pdv",
                table: "InvoiceItem",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "InvoiceItem",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pdv",
                table: "InvoiceItem");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "InvoiceItem");
        }
    }
}
