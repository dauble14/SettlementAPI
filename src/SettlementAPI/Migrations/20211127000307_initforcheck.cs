using Microsoft.EntityFrameworkCore.Migrations;

namespace SettlementAPI.Migrations
{
    public partial class initforcheck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_AspNetUsers_UserId",
                table: "Settlements");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2291a8e-4790-47d7-acd6-60d88ad3599f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb954ade-0b56-4530-9c79-d5a12cce8d1e");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Settlements",
                newName: "CreatedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Settlements_UserId",
                table: "Settlements",
                newName: "IX_Settlements_CreatedByUserId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "630b71f1-7cb7-4382-a37c-04e2edad5f95", "a95b8b47-d63c-4d20-9833-f956aab9b790", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "298ee579-c2d2-469d-9062-1713806f2e0b", "0ccbbe55-a862-4e01-bc2f-2d04b4883ecc", "Admin", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_AspNetUsers_CreatedByUserId",
                table: "Settlements",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_AspNetUsers_CreatedByUserId",
                table: "Settlements");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "298ee579-c2d2-469d-9062-1713806f2e0b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "630b71f1-7cb7-4382-a37c-04e2edad5f95");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserId",
                table: "Settlements",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Settlements_CreatedByUserId",
                table: "Settlements",
                newName: "IX_Settlements_UserId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b2291a8e-4790-47d7-acd6-60d88ad3599f", "061a7ffd-abb9-4b16-a43c-a959404e6565", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eb954ade-0b56-4530-9c79-d5a12cce8d1e", "76664d09-7a8b-43ea-b3e0-3d6c3e42ee95", "Admin", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_AspNetUsers_UserId",
                table: "Settlements",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
