using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest.EF;

public partial class AvioAssetChainDBContext : DbContext
{
    public AvioAssetChainDBContext()
    {
    }

    public AvioAssetChainDBContext(DbContextOptions<AvioAssetChainDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Asset> Assets { get; set; }

    public virtual DbSet<AssetDocument> AssetDocuments { get; set; }

    public virtual DbSet<AssetHistory> AssetHistories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:sqlservercboxtest.database.windows.net,1433;Database=AvioAssetChainDB;User ID=pomi-admin;Password=Addtech2021!;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AS");

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Asset>(entity =>
        {
            entity.HasKey(e => e.IdAsset);

            entity.ToTable("Asset");

            entity.Property(e => e.IdAsset).HasColumnName("ID_Asset");
            entity.Property(e => e.AssetGuid)
                .HasMaxLength(50)
                .HasColumnName("AssetGUID");
            entity.Property(e => e.AssetOwner).HasMaxLength(50);
            entity.Property(e => e.AssetParentGuid)
                .HasMaxLength(50)
                .HasColumnName("AssetParentGUID");
            entity.Property(e => e.IdParentAsset).HasColumnName("ID_ParentAsset");

            entity.HasOne(d => d.IdParentAssetNavigation).WithMany(p => p.InverseIdParentAssetNavigation)
                .HasForeignKey(d => d.IdParentAsset)
                .HasConstraintName("FK_Asset_Asset");
        });

        modelBuilder.Entity<AssetDocument>(entity =>
        {
            entity.HasKey(e => e.IdAssetDocument);

            entity.ToTable("AssetDocument");

            entity.Property(e => e.IdAssetDocument).HasColumnName("ID_AssetDocument");
            entity.Property(e => e.AssetContainerGuid)
                .HasMaxLength(50)
                .HasColumnName("AssetContainerGUID");
            entity.Property(e => e.AssetDocumentEditor).HasMaxLength(50);
            entity.Property(e => e.AssetDocumentGuid)
                .HasMaxLength(50)
                .HasColumnName("AssetDocumentGUID");

            entity.HasOne(d => d.AssetContainerNavigation).WithMany(p => p.AssetDocuments)
                .HasForeignKey(d => d.AssetContainer)
                .HasConstraintName("FK_AssetDocument_Asset");
        });

        modelBuilder.Entity<AssetHistory>(entity =>
        {
            entity.HasKey(e => e.IdAssetHistory);

            entity.ToTable("AssetHistory");

            entity.Property(e => e.IdAssetHistory).HasColumnName("ID_AssetHistory");
            entity.Property(e => e.AssetGuid)
                .HasMaxLength(50)
                .HasColumnName("AssetGUID");
            entity.Property(e => e.IdAsset).HasColumnName("ID_Asset");
            entity.Property(e => e.TransferDate).HasColumnType("datetime");

            entity.HasOne(d => d.IdAssetNavigation).WithMany(p => p.AssetHistories)
                .HasForeignKey(d => d.IdAsset)
                .HasConstraintName("FK_AssetHistory_Asset");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
