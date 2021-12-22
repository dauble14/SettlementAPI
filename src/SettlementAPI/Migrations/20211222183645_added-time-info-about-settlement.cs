using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SettlementAPI.Migrations
{
    public partial class addedtimeinfoaboutsettlement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c99fc05-3452-450b-9880-8c361dcd16a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "434ae40a-b954-46ea-bb4f-8ddc6c24dcca");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAtTime",
                table: "Settlements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAtTime",
                table: "Settlements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c04b11de-cb1a-4e7f-913e-0cc9d7c38828", "1f22b0a4-26ee-4ea4-a44e-f9fd8f2f2978", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2467d4b7-222f-49a3-af82-22cb38db6cc8", "a9a25ebf-2219-4aec-80f3-c19fbc408389", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2467d4b7-222f-49a3-af82-22cb38db6cc8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c04b11de-cb1a-4e7f-913e-0cc9d7c38828");

            migrationBuilder.DropColumn(
                name: "CreatedAtTime",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "ModifiedAtTime",
                table: "Settlements");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "434ae40a-b954-46ea-bb4f-8ddc6c24dcca", "2bebc08f-bf07-4f5f-a686-595e1d0e2a97", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0c99fc05-3452-450b-9880-8c361dcd16a7", "487f4ed8-3ff2-44f1-a1d6-9d9f32ce0d3b", "Admin", "ADMIN" });
        }
    }
}
