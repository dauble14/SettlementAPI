using Microsoft.EntityFrameworkCore.Migrations;

namespace SettlementAPI.Migrations
{   
    public partial class addeduseridinsettlement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_AspNetUsers_CreatedByUserId",
                table: "Settlements");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f67107b0-927a-415c-a3ca-ce9712b826ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9a4fda2-7917-4569-9027-56b7781c5b70");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "f9a4fda2-7917-4569-9027-56b7781c5b70", "2b88cea6-528f-4867-9154-c6cba0ced5c2", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f67107b0-927a-415c-a3ca-ce9712b826ed", "991fd721-e706-4ceb-b2aa-8565bcb8d0b1", "Admin", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_AspNetUsers_CreatedByUserId",
                table: "Settlements",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
