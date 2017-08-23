using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WMP.NHBC.DevDetective.CFEntityFramework.Models
{
    public partial class DevDetectiveContext : DbContext
    {
        public DevDetectiveContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Data Source=JACKSONHAYE1AEB\\SQLEXPRESS;Initial Catalog=DevDetective;Integrated Security=False;Persist Security Info=True;User ID=sa;Password={{Password Here Please}};MultipleActiveResultSets=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;Application Name=EntityFramework;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(builder);
        }

        public DevDetectiveContext(DbContextOptions<DevDetectiveContext> options ): base(options) { }

        public virtual DbSet<Facilities> Facilities { get; set; }
        public virtual DbSet<FacilityInventoryItemTypes> FacilityInventoryItemTypes { get; set; }
        public virtual DbSet<InventoryItemTypes> InventoryItemTypes { get; set; }
        public virtual DbSet<Tenants> Tenants { get; set; }
        public virtual DbSet<FacilityUser> FacilityUsers { get; set; }
        public virtual DbSet<FacilitySale> FacilitySales { get; set; }
        public virtual DbSet<FacilitySaleItem> FacilitySaleItems { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Facilities>(entity =>
            {
                entity.HasIndex(e => e.ParentFacilityId)
                    .HasName("IX_FK_Facility_ParentFacility");

                entity.HasIndex(e => e.TenantId)
                    .HasName("IX_FK_Facility_Tenant");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.ParentFacility)
                    .WithMany(p => p.InverseParentFacility)
                    .HasForeignKey(d => d.ParentFacilityId)
                    .HasConstraintName("FK_Facility_ParentFacility");

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.Facilities)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Facility_Tenant");
            });

            modelBuilder.Entity<FacilityInventoryItemTypes>(entity =>
            {
                entity.HasIndex(e => e.FacilityId)
                    .HasName("IX_FK_FacilityInventoryItemType_Facility");

                entity.HasIndex(e => e.InventoryItemTypeId)
                    .HasName("IX_FK_FacilityInventoryItemType_InventoryType");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Sku)
                    .HasColumnName("SKU")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Facility)
                    .WithMany(p => p.FacilityInventoryItemTypes)
                    .HasForeignKey(d => d.FacilityId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_FacilityInventoryItemType_Facility");

                entity.HasOne(d => d.InventoryItemType)
                    .WithMany(p => p.FacilityInventoryItemTypes)
                    .HasForeignKey(d => d.InventoryItemTypeId)
                    .HasConstraintName("FK_FacilityInventoryItemType_InventoryType");
            });

            modelBuilder.Entity<InventoryItemTypes>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Sku)
                    .HasColumnName("SKU")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Tenants>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<FacilityUser>()
             .HasKey(a => new { a.FacilityId, a.UserId });


            modelBuilder.Entity<FacilitySale>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            });
        }
    }
}