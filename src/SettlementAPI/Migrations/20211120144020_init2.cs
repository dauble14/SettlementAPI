using Microsoft.EntityFrameworkCore.Migrations;

namespace SettlementAPI.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Settlements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Settlements",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_UserId",
                table: "Settlements",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_Users_UserId",
                table: "Settlements",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_Users_UserId",
                table: "Settlements");

            migrationBuilder.DropIndex(
                name: "IX_Settlements_UserId",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Settlements");
        }
    }
}
