using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WMP.NHBC.DevDetective.CFEntityFramework.Models;

namespace WMP.NHBC.DevDetective.CFEntityFramework.Migrations
{
    [DbContext(typeof(DevDetectiveContext))]
    [Migration("20170815224139_addSale")]
    partial class addSale
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WMP.NHBC.DevDetective.CFEntityFramework.Models.Facilities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("ParentFacilityId");

                    b.Property<int>("TenantId");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("ParentFacilityId")
                        .HasName("IX_FK_Facility_ParentFacility");

                    b.HasIndex("TenantId")
                        .HasName("IX_FK_Facility_Tenant");

                    b.ToTable("Facilities");
                });

            modelBuilder.Entity("WMP.NHBC.DevDetective.CFEntityFramework.Models.FacilityInventoryItemTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("FacilityId");

                    b.Property<int?>("InventoryItemTypeId");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int?>("QuantityOnHand");

                    b.Property<int?>("QuantityOnOrder");

                    b.Property<string>("Sku")
                        .HasColumnName("SKU")
                        .HasColumnType("nchar(10)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("FacilityId")
                        .HasName("IX_FK_FacilityInventoryItemType_Facility");

                    b.HasIndex("InventoryItemTypeId")
                        .HasName("IX_FK_FacilityInventoryItemType_InventoryType");

                    b.ToTable("FacilityInventoryItemTypes");
                });

            modelBuilder.Entity("WMP.NHBC.DevDetective.CFEntityFramework.Models.FacilitySale", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("FacilityId");

                    b.HasKey("Id");

                    b.HasIndex("FacilityId");

                    b.ToTable("FacilitySales");
                });

            modelBuilder.Entity("WMP.NHBC.DevDetective.CFEntityFramework.Models.FacilitySaleItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FacilityInventoryItemTypeId");

                    b.Property<int>("FacilityItemId");

                    b.Property<Guid?>("FacilitySaleId");

                    b.Property<string>("Notes");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("FacilityInventoryItemTypeId");

                    b.HasIndex("FacilitySaleId");

                    b.ToTable("FacilitySaleItems");
                });

            modelBuilder.Entity("WMP.NHBC.DevDetective.CFEntityFramework.Models.FacilityUser", b =>
                {
                    b.Property<int>("FacilityId");

                    b.Property<string>("UserId");

                    b.HasKey("FacilityId", "UserId");

                    b.ToTable("FacilityUsers");
                });

            modelBuilder.Entity("WMP.NHBC.DevDetective.CFEntityFramework.Models.InventoryItemTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Sku")
                        .HasColumnName("SKU")
                        .HasColumnType("nchar(10)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("InventoryItemTypes");
                });

            modelBuilder.Entity("WMP.NHBC.DevDetective.CFEntityFramework.Models.Tenants", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("WMP.NHBC.DevDetective.CFEntityFramework.Models.Facilities", b =>
                {
                    b.HasOne("WMP.NHBC.DevDetective.CFEntityFramework.Models.Facilities", "ParentFacility")
                        .WithMany("InverseParentFacility")
                        .HasForeignKey("ParentFacilityId")
                        .HasConstraintName("FK_Facility_ParentFacility");

                    b.HasOne("WMP.NHBC.DevDetective.CFEntityFramework.Models.Tenants", "Tenant")
                        .WithMany("Facilities")
                        .HasForeignKey("TenantId")
                        .HasConstraintName("FK_Facility_Tenant");
                });

            modelBuilder.Entity("WMP.NHBC.DevDetective.CFEntityFramework.Models.FacilityInventoryItemTypes", b =>
                {
                    b.HasOne("WMP.NHBC.DevDetective.CFEntityFramework.Models.Facilities", "Facility")
                        .WithMany("FacilityInventoryItemTypes")
                        .HasForeignKey("FacilityId")
                        .HasConstraintName("FK_FacilityInventoryItemType_Facility");

                    b.HasOne("WMP.NHBC.DevDetective.CFEntityFramework.Models.InventoryItemTypes", "InventoryItemType")
                        .WithMany("FacilityInventoryItemTypes")
                        .HasForeignKey("InventoryItemTypeId")
                        .HasConstraintName("FK_FacilityInventoryItemType_InventoryType");
                });

            modelBuilder.Entity("WMP.NHBC.DevDetective.CFEntityFramework.Models.FacilitySale", b =>
                {
                    b.HasOne("WMP.NHBC.DevDetective.CFEntityFramework.Models.Facilities", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WMP.NHBC.DevDetective.CFEntityFramework.Models.FacilitySaleItem", b =>
                {
                    b.HasOne("WMP.NHBC.DevDetective.CFEntityFramework.Models.FacilityInventoryItemTypes", "FacilityInventoryItemType")
                        .WithMany()
                        .HasForeignKey("FacilityInventoryItemTypeId");

                    b.HasOne("WMP.NHBC.DevDetective.CFEntityFramework.Models.FacilitySale")
                        .WithMany("FacilitySaleItems")
                        .HasForeignKey("FacilitySaleId");
                });

            modelBuilder.Entity("WMP.NHBC.DevDetective.CFEntityFramework.Models.FacilityUser", b =>
                {
                    b.HasOne("WMP.NHBC.DevDetective.CFEntityFramework.Models.Facilities", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
