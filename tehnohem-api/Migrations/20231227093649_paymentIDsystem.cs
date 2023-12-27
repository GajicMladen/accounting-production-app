using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tehnohem_api.Migrations
{
    /// <inheritdoc />
    public partial class paymentIDsystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentIdSystem",
                table: "payments",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentIdSystem",
                table: "payments");
        }
    }
}
