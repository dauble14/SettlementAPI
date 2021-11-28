using Microsoft.EntityFrameworkCore.Migrations;

namespace SettlementAPI.Migrations
{
    public partial class clearentitiessetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_AspNetUsers_CreatedByUserId",
                table: "Settlements");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e458d57-ebc7-4425-9fbc-a3cb9425cb68");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "825a9e9c-9a7f-4a01-911f-f434101d9748");

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
                values: new object[] { "eeefd931-9e80-491e-aad4-9cae4e04298f", "2cee5083-ed0f-4620-a6e1-18bafb7b351a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cb1eb20e-ff5c-4252-8a0f-d2c73aeba043", "05c76b18-8370-463b-94b9-154f15a774be", "Admin", "ADMIN" });

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
                keyValue: "cb1eb20e-ff5c-4252-8a0f-d2c73aeba043");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eeefd931-9e80-491e-aad4-9cae4e04298f");

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
                values: new object[] { "825a9e9c-9a7f-4a01-911f-f434101d9748", "c18a8357-c053-4968-9b84-634a99436363", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3e458d57-ebc7-4425-9fbc-a3cb9425cb68", "6be4a81a-0c49-460e-bf5f-8c9d245693aa", "Admin", "ADMIN" });

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
