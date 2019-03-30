using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioControlSmart.WebApp.Data.Migrations
{
    public partial class DeviceEventConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceEvents_Devices_DeviceId",
                table: "DeviceEvents");

            migrationBuilder.AlterColumn<int>(
                name: "DeviceId",
                table: "DeviceEvents",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "DeviceEvents",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Timestamp",
                table: "DeviceEvents",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceEvents_Devices_DeviceId",
                table: "DeviceEvents",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceEvents_Devices_DeviceId",
                table: "DeviceEvents");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "DeviceEvents");

            migrationBuilder.AlterColumn<int>(
                name: "DeviceId",
                table: "DeviceEvents",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "DeviceEvents",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceEvents_Devices_DeviceId",
                table: "DeviceEvents",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
