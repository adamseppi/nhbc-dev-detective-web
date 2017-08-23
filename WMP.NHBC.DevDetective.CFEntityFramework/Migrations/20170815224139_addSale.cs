using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WMP.NHBC.DevDetective.CFEntityFramework.Migrations
{
    public partial class addSale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FacilitySales",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    FacilityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilitySales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacilitySales_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacilitySaleItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FacilityInventoryItemTypeId = table.Column<int>(nullable: true),
                    FacilityItemId = table.Column<int>(nullable: false),
                    FacilitySaleId = table.Column<Guid>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilitySaleItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacilitySaleItems_FacilityInventoryItemTypes_FacilityInventoryItemTypeId",
                        column: x => x.FacilityInventoryItemTypeId,
                        principalTable: "FacilityInventoryItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FacilitySaleItems_FacilitySales_FacilitySaleId",
                        column: x => x.FacilitySaleId,
                        principalTable: "FacilitySales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FacilitySales_FacilityId",
                table: "FacilitySales",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilitySaleItems_FacilityInventoryItemTypeId",
                table: "FacilitySaleItems",
                column: "FacilityInventoryItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilitySaleItems_FacilitySaleId",
                table: "FacilitySaleItems",
                column: "FacilitySaleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacilitySaleItems");

            migrationBuilder.DropTable(
                name: "FacilitySales");
        }
    }
}
