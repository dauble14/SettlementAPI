using Microsoft.EntityFrameworkCore.Migrations;

namespace SettlementAPI.Migrations
{
    public partial class addedfriendsdbset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friend_AspNetUsers_FriendUserId",
                table: "Friend");

            migrationBuilder.DropForeignKey(
                name: "FK_Friend_AspNetUsers_UserId",
                table: "Friend");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Friend",
                table: "Friend");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46dd48a0-566a-4ca3-9c50-97e9ccad3adf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4763c34b-c9ce-466e-8960-14a2a5d3612c");

            migrationBuilder.RenameTable(
                name: "Friend",
                newName: "Friends");

            migrationBuilder.RenameIndex(
                name: "IX_Friend_UserId",
                table: "Friends",
                newName: "IX_Friends_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Friend_FriendUserId",
                table: "Friends",
                newName: "IX_Friends_FriendUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friends",
                table: "Friends",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "434ae40a-b954-46ea-bb4f-8ddc6c24dcca", "2bebc08f-bf07-4f5f-a686-595e1d0e2a97", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0c99fc05-3452-450b-9880-8c361dcd16a7", "487f4ed8-3ff2-44f1-a1d6-9d9f32ce0d3b", "Admin", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_AspNetUsers_FriendUserId",
                table: "Friends",
                column: "FriendUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_AspNetUsers_UserId",
                table: "Friends",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friends_AspNetUsers_FriendUserId",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_AspNetUsers_UserId",
                table: "Friends");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Friends",
                table: "Friends");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c99fc05-3452-450b-9880-8c361dcd16a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "434ae40a-b954-46ea-bb4f-8ddc6c24dcca");

            migrationBuilder.RenameTable(
                name: "Friends",
                newName: "Friend");

            migrationBuilder.RenameIndex(
                name: "IX_Friends_UserId",
                table: "Friend",
                newName: "IX_Friend_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Friends_FriendUserId",
                table: "Friend",
                newName: "IX_Friend_FriendUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friend",
                table: "Friend",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4763c34b-c9ce-466e-8960-14a2a5d3612c", "35c6e9f4-2938-4afe-969f-5e57f0d87658", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "46dd48a0-566a-4ca3-9c50-97e9ccad3adf", "f9d7ea88-5231-491b-a67e-2ff2ff3f55af", "Admin", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_Friend_AspNetUsers_FriendUserId",
                table: "Friend",
                column: "FriendUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friend_AspNetUsers_UserId",
                table: "Friend",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
