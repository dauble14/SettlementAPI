using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SettlementAPI.Migrations
{
    public partial class moneytransfersendedtimeprop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b387f2f-722d-4d1e-88ed-2329bc22e87b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9a42370-988b-4c92-b303-b0144b36841b");

            migrationBuilder.AddColumn<DateTime>(
                name: "SendedAtTime",
                table: "MoneyTransfers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c9c85b64-ee6e-4a11-8dc1-1875c1d23da2", "56e2bab1-6b34-44ff-b110-ba9f36e29641", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e897fb68-93aa-4ca0-a054-569b4ceeef34", "da2fe09a-6cd0-4892-8cbe-03569ad2ad50", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9c85b64-ee6e-4a11-8dc1-1875c1d23da2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e897fb68-93aa-4ca0-a054-569b4ceeef34");

            migrationBuilder.DropColumn(
                name: "SendedAtTime",
                table: "MoneyTransfers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a9a42370-988b-4c92-b303-b0144b36841b", "275aad33-c551-486f-84fa-601f4f561dc4", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0b387f2f-722d-4d1e-88ed-2329bc22e87b", "58ca6380-def5-41ba-9d0f-279ceb8a6d5e", "Admin", "ADMIN" });
        }
    }
}
