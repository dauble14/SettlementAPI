using Microsoft.EntityFrameworkCore.Migrations;

namespace SettlementAPI.Migrations
{
    public partial class addedfriendinvitationcode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b33f7c5-e6f7-4ac5-8eef-eb6e334360b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6569e4f6-8559-436d-86a3-1c564a823a8f");

            migrationBuilder.AddColumn<string>(
                name: "FriendIdCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4763c34b-c9ce-466e-8960-14a2a5d3612c", "35c6e9f4-2938-4afe-969f-5e57f0d87658", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "46dd48a0-566a-4ca3-9c50-97e9ccad3adf", "f9d7ea88-5231-491b-a67e-2ff2ff3f55af", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46dd48a0-566a-4ca3-9c50-97e9ccad3adf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4763c34b-c9ce-466e-8960-14a2a5d3612c");

            migrationBuilder.DropColumn(
                name: "FriendIdCode",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0b33f7c5-e6f7-4ac5-8eef-eb6e334360b1", "012cb616-49a8-4d1c-a14f-0cee463290f2", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6569e4f6-8559-436d-86a3-1c564a823a8f", "162eb090-75ec-4213-9230-3590bd2bb94a", "Admin", "ADMIN" });
        }
    }
}
