using Microsoft.EntityFrameworkCore.Migrations;

namespace SettlementAPI.Migrations
{
    public partial class moneyTransferisacceptedByReceiverupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9c85b64-ee6e-4a11-8dc1-1875c1d23da2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e897fb68-93aa-4ca0-a054-569b4ceeef34");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c9c85b64-ee6e-4a11-8dc1-1875c1d23da2", "56e2bab1-6b34-44ff-b110-ba9f36e29641", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e897fb68-93aa-4ca0-a054-569b4ceeef34", "da2fe09a-6cd0-4892-8cbe-03569ad2ad50", "Admin", "ADMIN" });
        }
    }
}
