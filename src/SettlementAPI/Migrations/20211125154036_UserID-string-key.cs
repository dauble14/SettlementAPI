using Microsoft.EntityFrameworkCore.Migrations;

namespace SettlementAPI.Migrations
{
    public partial class UserIDstringkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSettlement_AspNetUsers_UserId1",
                table: "ProductSettlement");

            migrationBuilder.DropIndex(
                name: "IX_ProductSettlement_UserId1",
                table: "ProductSettlement");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "021cb3dd-e8c2-4df5-9767-34d56878def3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "825f4a70-470d-4e97-9b7d-af54ceba8450");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ProductSettlement");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ProductSettlement",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d4a74575-b2ae-4052-a45a-9b33aba83dd4", "9cfc8082-20c8-4608-ae1c-f0491ca00853", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c8cb373-d815-4b27-9448-2cd56bb326ac", "496ee40e-162a-4806-b1b9-49b5192761a2", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSettlement_UserId",
                table: "ProductSettlement",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSettlement_AspNetUsers_UserId",
                table: "ProductSettlement",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSettlement_AspNetUsers_UserId",
                table: "ProductSettlement");

            migrationBuilder.DropIndex(
                name: "IX_ProductSettlement_UserId",
                table: "ProductSettlement");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c8cb373-d815-4b27-9448-2cd56bb326ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4a74575-b2ae-4052-a45a-9b33aba83dd4");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ProductSettlement",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "ProductSettlement",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "021cb3dd-e8c2-4df5-9767-34d56878def3", "6d0f8338-fdf6-4b53-a291-69cd11bd2f87", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "825f4a70-470d-4e97-9b7d-af54ceba8450", "9978c878-ad2c-429c-80fb-5e3630d78a86", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSettlement_UserId1",
                table: "ProductSettlement",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSettlement_AspNetUsers_UserId1",
                table: "ProductSettlement",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
