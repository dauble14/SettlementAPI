using Microsoft.EntityFrameworkCore.Migrations;

namespace SettlementAPI.Migrations
{
    public partial class deletedusedidinproductsettlement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "298ee579-c2d2-469d-9062-1713806f2e0b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "630b71f1-7cb7-4382-a37c-04e2edad5f95");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "825a9e9c-9a7f-4a01-911f-f434101d9748", "c18a8357-c053-4968-9b84-634a99436363", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3e458d57-ebc7-4425-9fbc-a3cb9425cb68", "6be4a81a-0c49-460e-bf5f-8c9d245693aa", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e458d57-ebc7-4425-9fbc-a3cb9425cb68");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "825a9e9c-9a7f-4a01-911f-f434101d9748");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "630b71f1-7cb7-4382-a37c-04e2edad5f95", "a95b8b47-d63c-4d20-9833-f956aab9b790", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "298ee579-c2d2-469d-9062-1713806f2e0b", "0ccbbe55-a862-4e01-bc2f-2d04b4883ecc", "Admin", "ADMIN" });
        }
    }
}
