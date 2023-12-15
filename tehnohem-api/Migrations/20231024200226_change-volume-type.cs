using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace tehnohem_api.Migrations
{
    /// <inheritdoc />
    public partial class changevolumetype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

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

            migrationBuilder.AlterColumn<string>(
                name: "Volume",
                table: "Products",
                type: "text",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ID");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "BarCode", "CurrentAmount", "Name", "SinglePrice", "TotalPrice", "Volume" },
                values: new object[,]
                {
                    { 1, "13246587", 130f, "Sirce", 0.93f, 930.76f, "1/1" },
                    { 2, "1112223333", 70f, "Sirce", 2.93f, 1830.76f, "3/1" },
                    { 3, "3333555999", 570f, "Rival Glass", 1.43f, 1500.76f, "0.75/1" },
                    { 4, "98789321", 986f, "Tasko Maxi", 5.13f, 2530.76f, "5/1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyColumnType: "integer",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyColumnType: "integer",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyColumnType: "integer",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyColumnType: "integer",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Products");

            migrationBuilder.AlterColumn<float>(
                name: "Volume",
                table: "Products",
                type: "real",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "BarCode");

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
    }
}
