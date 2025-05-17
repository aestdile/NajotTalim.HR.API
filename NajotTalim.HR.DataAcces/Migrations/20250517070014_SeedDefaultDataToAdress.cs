using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NajotTalim.HR.DataAcces.Migrations
{
    public partial class SeedDefaultDataToAdress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "'sample@email.com'",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Adresses",
                columns: new[] { "Id", "AdressLine1", "AdressLine2", "City", "Country", "PostalCode" },
                values: new object[] { 10001, "76, Uzar Street", "Sergeli Region", "Tashkent", "Uzbekistan", "7007" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Adresses",
                keyColumn: "Id",
                keyValue: 10001);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValueSql: "'sample@email.com'");
        }
    }
}
