using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WMP.NHBC.DevDetective.CFEntityFramework.Migrations
{
    public partial class updateFAcilitySaleFKname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacilitySaleItems_FacilityInventoryItemTypes_FacilityInventoryItemTypeId",
                table: "FacilitySaleItems");

            migrationBuilder.DropForeignKey(
                name: "FK_FacilitySaleItems_FacilitySales_FacilitySaleId",
                table: "FacilitySaleItems");

            migrationBuilder.DropColumn(
                name: "FacilityItemId",
                table: "FacilitySaleItems");

            migrationBuilder.AlterColumn<Guid>(
                name: "FacilitySaleId",
                table: "FacilitySaleItems",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FacilityInventoryItemTypeId",
                table: "FacilitySaleItems",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FacilitySaleItems_FacilityInventoryItemTypes_FacilityInventoryItemTypeId",
                table: "FacilitySaleItems",
                column: "FacilityInventoryItemTypeId",
                principalTable: "FacilityInventoryItemTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FacilitySaleItems_FacilitySales_FacilitySaleId",
                table: "FacilitySaleItems",
                column: "FacilitySaleId",
                principalTable: "FacilitySales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacilitySaleItems_FacilityInventoryItemTypes_FacilityInventoryItemTypeId",
                table: "FacilitySaleItems");

            migrationBuilder.DropForeignKey(
                name: "FK_FacilitySaleItems_FacilitySales_FacilitySaleId",
                table: "FacilitySaleItems");

            migrationBuilder.AlterColumn<Guid>(
                name: "FacilitySaleId",
                table: "FacilitySaleItems",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<int>(
                name: "FacilityInventoryItemTypeId",
                table: "FacilitySaleItems",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "FacilityItemId",
                table: "FacilitySaleItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_FacilitySaleItems_FacilityInventoryItemTypes_FacilityInventoryItemTypeId",
                table: "FacilitySaleItems",
                column: "FacilityInventoryItemTypeId",
                principalTable: "FacilityInventoryItemTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FacilitySaleItems_FacilitySales_FacilitySaleId",
                table: "FacilitySaleItems",
                column: "FacilitySaleId",
                principalTable: "FacilitySales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
