using Microsoft.EntityFrameworkCore.Migrations;

namespace Smart_ChargingApi.Migrations
{
    public partial class InitilFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChargeStations_Groups_GroupId",
                table: "ChargeStations");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "ChargeStations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChargeStations_Groups_GroupId",
                table: "ChargeStations",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChargeStations_Groups_GroupId",
                table: "ChargeStations");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "ChargeStations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ChargeStations_Groups_GroupId",
                table: "ChargeStations",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
