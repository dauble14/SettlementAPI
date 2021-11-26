using Microsoft.EntityFrameworkCore.Migrations;

namespace SettlementAPI.Migrations
{
    public partial class modifieduseridkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSettlement_AspNetUsers_UserId1",
                table: "ProductSettlement");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bbc84b7-f5fb-4200-a958-b82b41c28dad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5ad964f-e06d-4cf7-9dcb-85cf4866dfba");

            migrationBuilder.AlterColumn<string>(
                name: "UserId1",
                table: "ProductSettlement",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "021cb3dd-e8c2-4df5-9767-34d56878def3", "6d0f8338-fdf6-4b53-a291-69cd11bd2f87", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "825f4a70-470d-4e97-9b7d-af54ceba8450", "9978c878-ad2c-429c-80fb-5e3630d78a86", "Admin", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSettlement_AspNetUsers_UserId1",
                table: "ProductSettlement",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSettlement_AspNetUsers_UserId1",
                table: "ProductSettlement");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "021cb3dd-e8c2-4df5-9767-34d56878def3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "825f4a70-470d-4e97-9b7d-af54ceba8450");

            migrationBuilder.AlterColumn<string>(
                name: "UserId1",
                table: "ProductSettlement",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a5ad964f-e06d-4cf7-9dcb-85cf4866dfba", "0869fb01-b1d7-4b61-ac82-9ae9d44fa9b6", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3bbc84b7-f5fb-4200-a958-b82b41c28dad", "980b4905-291b-477e-bb97-1e00055a77e1", "Admin", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSettlement_AspNetUsers_UserId1",
                table: "ProductSettlement",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
