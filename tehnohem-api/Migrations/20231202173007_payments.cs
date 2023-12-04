using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tehnohem_api.Migrations
{
    /// <inheritdoc />
    public partial class payments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    PaymentId = table.Column<string>(type: "text", nullable: false),
                    PaymentType = table.Column<int>(type: "integer", nullable: false),
                    PayerID = table.Column<string>(type: "text", nullable: true),
                    ReceiverID = table.Column<string>(type: "text", nullable: true),
                    TotalValue = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_payments_Company_PayerID",
                        column: x => x.PayerID,
                        principalTable: "Company",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_payments_Company_ReceiverID",
                        column: x => x.ReceiverID,
                        principalTable: "Company",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PaymentItem",
                columns: table => new
                {
                    ID = table.Column<string>(type: "text", nullable: false),
                    PaymentID = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PaymentItem_payments_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "payments",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentItem_PaymentID",
                table: "PaymentItem",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_payments_PayerID",
                table: "payments",
                column: "PayerID");

            migrationBuilder.CreateIndex(
                name: "IX_payments_ReceiverID",
                table: "payments",
                column: "ReceiverID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentItem");

            migrationBuilder.DropTable(
                name: "payments");
        }
    }
}
