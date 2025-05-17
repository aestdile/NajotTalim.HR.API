using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NajotTalim.HR.DataAcces.Migrations
{
    public partial class AddedAdressIdToEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdressId",
                table: "Employees",
                type: "int",
                nullable: true); // nullable qilib qo'yildi

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AdressId",
                table: "Employees",
                column: "AdressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Adresses_AdressId",
                table: "Employees",
                column: "AdressId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull); // O'chirilsa NULL bo'ladi
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Adresses_AdressId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_AdressId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "AdressId",
                table: "Employees");
        }

    }
}
