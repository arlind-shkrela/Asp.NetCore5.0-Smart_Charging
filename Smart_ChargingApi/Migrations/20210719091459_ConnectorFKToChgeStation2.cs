using Microsoft.EntityFrameworkCore.Migrations;

namespace Smart_ChargingApi.Migrations
{
    public partial class ConnectorFKToChgeStation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChargeStations_Connectors_ConnectorId",
                table: "ChargeStations");

            migrationBuilder.AlterColumn<int>(
                name: "ConnectorId",
                table: "ChargeStations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ChargeStations_Connectors_ConnectorId",
                table: "ChargeStations",
                column: "ConnectorId",
                principalTable: "Connectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChargeStations_Connectors_ConnectorId",
                table: "ChargeStations");

            migrationBuilder.AlterColumn<int>(
                name: "ConnectorId",
                table: "ChargeStations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChargeStations_Connectors_ConnectorId",
                table: "ChargeStations",
                column: "ConnectorId",
                principalTable: "Connectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
