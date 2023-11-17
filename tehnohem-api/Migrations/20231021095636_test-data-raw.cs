using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace tehnohem_api.Migrations
{
    /// <inheritdoc />
    public partial class testdataraw : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Raws",
                columns: new[] { "ID", "CurrentAmount", "Name", "RawType", "SinglePrice", "TotalPrice" },
                values: new object[,]
                {
                    { 1, 25f, "Sircetna kiselina", 0, 0.95f, 23.75f },
                    { 2, 22f, "Luzina", 0, 0.95f, 21.75f },
                    { 3, 1000f, "Sirce 1/1", 1, 0.12f, 120f },
                    { 4, 500f, "Deter 5/1", 1, 0.5f, 250f },
                    { 5, 700f, "Sirce 3/1", 0, 0.4f, 300.65f },
                    { 6, 3000f, "Zuti f40", 2, 0.1f, 300f },
                    { 7, 2500f, "Plavi f40", 2, 0.12f, 260f },
                    { 8, 25f, "Zeleni pipak", 2, 0.95f, 23.75f },
                    { 9, 7800f, "Plava pumpica", 0, 0.4f, 3500f },
                    { 10, 2500f, "Sircetna kiselina 1/1", 3, 0.05f, 200f },
                    { 11, 2500f, "Sircetna kiselina 3/1", 3, 0.05f, 200f },
                    { 12, 2500f, "Tasko Maxi 0.25/1", 3, 0.05f, 200f },
                    { 13, 2500f, "Sona kiselina1/1", 3, 0.05f, 200f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Raws",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Raws",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Raws",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Raws",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Raws",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Raws",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Raws",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Raws",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Raws",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Raws",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Raws",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Raws",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Raws",
                keyColumn: "ID",
                keyValue: 13);
        }
    }
}
