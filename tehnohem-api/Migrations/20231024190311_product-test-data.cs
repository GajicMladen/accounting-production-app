using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace tehnohem_api.Migrations
{
    /// <inheritdoc />
    public partial class producttestdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "BarCode", "CurrentAmount", "Name", "SinglePrice", "TotalPrice", "Volume" },
                values: new object[,]
                {
                    { "1112223333", 70f, "Sirce", 2.93f, 1830.76f, 3f },
                    { "13246587", 130f, "Sirce", 0.93f, 930.76f, 1f },
                    { "3333555999", 570f, "Rival Glass", 1.43f, 1500.76f, 0.75f },
                    { "98789321", 986f, "Tasko Maxi", 5.13f, 2530.76f, 5f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "BarCode",
                keyValue: "1112223333");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "BarCode",
                keyValue: "13246587");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "BarCode",
                keyValue: "3333555999");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "BarCode",
                keyValue: "98789321");
        }
    }
}
