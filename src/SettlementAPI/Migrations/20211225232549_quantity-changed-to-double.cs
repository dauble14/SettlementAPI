using Microsoft.EntityFrameworkCore.Migrations;

namespace SettlementAPI.Migrations
{
    public partial class quantitychangedtodouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61ab013b-6eb8-4a00-bf5b-6fed7a7a3168");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ef24db6-36bb-4e51-b180-4ebbda1296d2");

            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "ProductSettlements",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8633acd5-f53f-4cb1-822b-ef6fa3a9ff16", "4cbce965-25ff-4a4f-8075-e0a05a4e68b9", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e57fc511-28e6-431c-862e-62b248d75529", "a33fbf3f-151d-4408-87a3-e84608e3488a", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8633acd5-f53f-4cb1-822b-ef6fa3a9ff16");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e57fc511-28e6-431c-862e-62b248d75529");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "ProductSettlements",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "61ab013b-6eb8-4a00-bf5b-6fed7a7a3168", "3dd7daa2-bf42-4e73-822e-2412738c38ee", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8ef24db6-36bb-4e51-b180-4ebbda1296d2", "ccfc3388-8dc6-4403-9ca9-85e37ae0e753", "Admin", "ADMIN" });
        }
    }
}
