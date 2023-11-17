using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace tehnohem_api.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    ID = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    JIB = table.Column<string>(type: "text", nullable: false),
                    IB = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    companyType = table.Column<int>(type: "integer", nullable: false),
                    HeadCompanyID = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Company_Company_HeadCompanyID",
                        column: x => x.HeadCompanyID,
                        principalTable: "Company",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    BarCode = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Volume = table.Column<float>(type: "real", nullable: false),
                    SinglePrice = table.Column<float>(type: "real", nullable: false),
                    CurrentAmount = table.Column<float>(type: "real", nullable: false),
                    TotalPrice = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.BarCode);
                });

            migrationBuilder.CreateTable(
                name: "Raws",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SinglePrice = table.Column<float>(type: "real", nullable: false),
                    CurrentAmount = table.Column<float>(type: "real", nullable: false),
                    TotalPrice = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raws", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    ID = table.Column<string>(type: "text", nullable: false),
                    InvoiceType = table.Column<int>(type: "integer", nullable: false),
                    SupplierID = table.Column<string>(type: "text", nullable: true),
                    CustomerID = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    TotalPrice = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Invoices_Company_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Company",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Invoices_Company_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Company",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DatePeriod",
                columns: table => new
                {
                    InvoiceID = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_DatePeriod_Invoices_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoices",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItem",
                columns: table => new
                {
                    ID = table.Column<string>(type: "text", nullable: false),
                    InvoiceID = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SinglePrice = table.Column<float>(type: "real", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    TotalPrice = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InvoiceItem_Invoices_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "ID", "Address", "Email", "HeadCompanyID", "IB", "JIB", "Name", "PhoneNumber", "companyType" },
                values: new object[,]
                {
                    { "1", "Svetog Save 18, Zvornik", null, null, "123456", "123456789", "Zvornicanka d.o.o", null, 1 },
                    { "2", "Kralja PEtra 11, Orahovac", null, null, "123456", "123456789", "M&V d.o.o", null, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_HeadCompanyID",
                table: "Company",
                column: "HeadCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_DatePeriod_InvoiceID",
                table: "DatePeriod",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItem_InvoiceID",
                table: "InvoiceItem",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerID",
                table: "Invoices",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_SupplierID",
                table: "Invoices",
                column: "SupplierID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DatePeriod");

            migrationBuilder.DropTable(
                name: "InvoiceItem");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Raws");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
