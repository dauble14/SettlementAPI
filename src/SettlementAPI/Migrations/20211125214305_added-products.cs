using Microsoft.EntityFrameworkCore.Migrations;

namespace SettlementAPI.Migrations
{
    public partial class addedproducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSettlement_Product_ProductId",
                table: "ProductSettlement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c8cb373-d815-4b27-9448-2cd56bb326ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4a74575-b2ae-4052-a45a-9b33aba83dd4");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f9a4fda2-7917-4569-9027-56b7781c5b70", "2b88cea6-528f-4867-9154-c6cba0ced5c2", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f67107b0-927a-415c-a3ca-ce9712b826ed", "991fd721-e706-4ceb-b2aa-8565bcb8d0b1", "Admin", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSettlement_Products_ProductId",
                table: "ProductSettlement",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSettlement_Products_ProductId",
                table: "ProductSettlement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f67107b0-927a-415c-a3ca-ce9712b826ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9a4fda2-7917-4569-9027-56b7781c5b70");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ProductId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d4a74575-b2ae-4052-a45a-9b33aba83dd4", "9cfc8082-20c8-4608-ae1c-f0491ca00853", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c8cb373-d815-4b27-9448-2cd56bb326ac", "496ee40e-162a-4806-b1b9-49b5192761a2", "Admin", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSettlement_Product_ProductId",
                table: "ProductSettlement",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
