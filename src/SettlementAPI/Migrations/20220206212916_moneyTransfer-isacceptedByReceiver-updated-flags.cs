using Microsoft.EntityFrameworkCore.Migrations;

namespace SettlementAPI.Migrations
{
    public partial class moneyTransferisacceptedByReceiverupdatedflags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e5e74b8-5297-4c1f-a524-5bf8ce676e21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94e5196c-bbeb-4eb6-a155-5fbb5a19c3b4");

            migrationBuilder.DropColumn(
                name: "IsAcceptedByReceiver",
                table: "MoneyTransfers");

            migrationBuilder.AddColumn<int>(
                name: "TransferRequestFlag",
                table: "MoneyTransfers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fb690633-7ec9-427b-8eeb-0f0a1a4679ac", "c680ad90-08fb-4fe8-bb06-8a2fbfc01906", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fcace621-a993-4201-b77f-499794cc2f31", "68343d37-160e-499d-aea2-bfb86caad356", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb690633-7ec9-427b-8eeb-0f0a1a4679ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcace621-a993-4201-b77f-499794cc2f31");

            migrationBuilder.DropColumn(
                name: "TransferRequestFlag",
                table: "MoneyTransfers");

            migrationBuilder.AddColumn<bool>(
                name: "IsAcceptedByReceiver",
                table: "MoneyTransfers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3e5e74b8-5297-4c1f-a524-5bf8ce676e21", "d734b036-58a5-4880-a54b-f416494e13f5", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "94e5196c-bbeb-4eb6-a155-5fbb5a19c3b4", "e649eefe-a95f-41b4-850e-2de71c2888f9", "Admin", "ADMIN" });
        }
    }
}
