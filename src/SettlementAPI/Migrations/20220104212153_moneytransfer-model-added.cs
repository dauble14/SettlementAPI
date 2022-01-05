using Microsoft.EntityFrameworkCore.Migrations;

namespace SettlementAPI.Migrations
{
    public partial class moneytransfermodeladded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8633acd5-f53f-4cb1-822b-ef6fa3a9ff16");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e57fc511-28e6-431c-862e-62b248d75529");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "584e4cfe-2616-4690-863a-da10a5bee536", "962016a5-dec3-49c7-98bb-59fb9943e0fa", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1ca3e8a4-fe97-42fa-a52a-30a60954f627", "4e41d3ac-3752-4a05-8a95-0761fe6f1877", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ca3e8a4-fe97-42fa-a52a-30a60954f627");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "584e4cfe-2616-4690-863a-da10a5bee536");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8633acd5-f53f-4cb1-822b-ef6fa3a9ff16", "4cbce965-25ff-4a4f-8075-e0a05a4e68b9", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e57fc511-28e6-431c-862e-62b248d75529", "a33fbf3f-151d-4408-87a3-e84608e3488a", "Admin", "ADMIN" });
        }
    }
}
