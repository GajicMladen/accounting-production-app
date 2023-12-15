using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tehnohem_api.Migrations
{
    /// <inheritdoc />
    public partial class smallchangescompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactPerson",
                table: "Company",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "ID",
                keyValue: "1",
                column: "ContactPerson",
                value: null);

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "ID",
                keyValue: "2",
                column: "ContactPerson",
                value: null);

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "ID",
                keyValue: "3",
                column: "ContactPerson",
                value: null);

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "ID",
                keyValue: "4",
                column: "ContactPerson",
                value: null);

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "ID",
                keyValue: "5",
                column: "ContactPerson",
                value: null);

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "ID",
                keyValue: "6",
                column: "ContactPerson",
                value: null);

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "ID",
                keyValue: "7",
                column: "ContactPerson",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactPerson",
                table: "Company");
        }
    }
}
