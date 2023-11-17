using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tehnohem_api.Migrations
{
    /// <inheritdoc />
    public partial class addedinvoiceItemID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "itemID",
                table: "InvoiceItem",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "itemID",
                table: "InvoiceItem");
        }
    }
}
