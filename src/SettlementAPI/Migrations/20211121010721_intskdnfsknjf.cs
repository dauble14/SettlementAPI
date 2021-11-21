using Microsoft.EntityFrameworkCore.Migrations;

namespace SettlementAPI.Migrations
{
    public partial class intskdnfsknjf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_Users_UserId",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Settlements");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Settlements",
                newName: "CreatedByUserUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Settlements_UserId",
                table: "Settlements",
                newName: "IX_Settlements_CreatedByUserUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_Users_CreatedByUserUserId",
                table: "Settlements",
                column: "CreatedByUserUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_Users_CreatedByUserUserId",
                table: "Settlements");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserUserId",
                table: "Settlements",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Settlements_CreatedByUserUserId",
                table: "Settlements",
                newName: "IX_Settlements_UserId");

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Settlements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_Users_UserId",
                table: "Settlements",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
