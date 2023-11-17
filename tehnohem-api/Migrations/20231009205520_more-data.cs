using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace tehnohem_api.Migrations
{
    /// <inheritdoc />
    public partial class moredata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "ID", "Address", "Email", "HeadCompanyID", "IB", "JIB", "Name", "PhoneNumber", "companyType" },
                values: new object[,]
                {
                    { "3", "Nebeska, Busovaca", null, null, "123456", "123456789", "Tisal d.o.o", null, 0 },
                    { "4", "Zakasta 10, Tuzla", null, null, "123456", "123456789", "Tuzla Plast d.o.o", null, 0 },
                    { "5", "Mire Mitica 20, Ugljevik", null, null, "123456", "123456789", "Eco d.o.o", null, 1 },
                    { "6", "Grobnice, Zvornik", null, null, "123456", "123456789", "Miroslav Dronjak", null, 3 },
                    { "7", "Limenacka 32, Sarajevo", null, null, "123456", "123456789", "Elektrodistribucija", null, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "ID",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "ID",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "ID",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "ID",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "ID",
                keyValue: "7");
        }
    }
}
