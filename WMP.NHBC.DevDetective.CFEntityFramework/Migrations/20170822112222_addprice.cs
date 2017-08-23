using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WMP.NHBC.DevDetective.CFEntityFramework.Migrations
{
    public partial class addprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "InventoryItemTypes",
                nullable: false,
                defaultValue: 5m);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "FacilityInventoryItemTypes",
                nullable: false,
                defaultValue: 5m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "InventoryItemTypes");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "FacilityInventoryItemTypes");
        }
    }
}
