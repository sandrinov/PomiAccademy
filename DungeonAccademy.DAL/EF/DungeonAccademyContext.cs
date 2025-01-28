using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DungeonAccademy.DAL.EF;

public partial class DungeonAccademyContext : DbContext
{
    public DungeonAccademyContext()
    {
    }

    public DungeonAccademyContext(DbContextOptions<DungeonAccademyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<CharactersXroom> CharactersXrooms { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemsXroom> ItemsXrooms { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:sqlservercboxtest.database.windows.net,1433;Database=DungeonAccademy_3;User ID=pomi-admin;Password=Addtech2021!;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Character>(entity =>
        {
            entity.HasKey(e => e.IdCharacter);

            entity.Property(e => e.IdCharacter).HasColumnName("ID_Character");
            entity.Property(e => e.Health).HasDefaultValue(100);
            entity.Property(e => e.IdGame).HasColumnName("ID_Game");
            entity.Property(e => e.NickName).HasMaxLength(50);
            entity.Property(e => e.TypeCharacter).HasMaxLength(50);

            entity.HasOne(d => d.IdGameNavigation).WithMany(p => p.Characters)
                .HasForeignKey(d => d.IdGame)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Characters_Games");
        });

        modelBuilder.Entity<CharactersXroom>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CharactersXRooms");

            entity.Property(e => e.IdCharacter).HasColumnName("ID_Character");
            entity.Property(e => e.IdCharacterXroom)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_CharacterXRoom");
            entity.Property(e => e.IdRoom).HasColumnName("ID_Room");

            entity.HasOne(d => d.IdCharacterNavigation).WithMany()
                .HasForeignKey(d => d.IdCharacter)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CharactersXRooms_Characters");

            entity.HasOne(d => d.IdRoomNavigation).WithMany()
                .HasForeignKey(d => d.IdRoom)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CharactersXRooms_Rooms");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.IdGame);

            entity.Property(e => e.IdGame).HasColumnName("ID_Game");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.IdItem);

            entity.Property(e => e.IdItem).HasColumnName("ID_Item");
        });

        modelBuilder.Entity<ItemsXroom>(entity =>
        {
            entity.HasKey(e => e.IdItemsXrooms);

            entity.ToTable("ItemsXRooms");

            entity.Property(e => e.IdItemsXrooms).HasColumnName("ID_ItemsXRooms");
            entity.Property(e => e.IdCharacter).HasColumnName("ID_Character");
            entity.Property(e => e.IdItem).HasColumnName("ID_Item");
            entity.Property(e => e.IdRoom).HasColumnName("ID_Room");
            entity.Property(e => e.IsCollectable).HasDefaultValue(true);

            entity.HasOne(d => d.IdItemNavigation).WithMany(p => p.ItemsXrooms)
                .HasForeignKey(d => d.IdItem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItemsXRooms_Items");

            entity.HasOne(d => d.IdRoomNavigation).WithMany(p => p.ItemsXrooms)
                .HasForeignKey(d => d.IdRoom)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItemsXRooms_Rooms");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.IdRoom);

            entity.Property(e => e.IdRoom).HasColumnName("ID_Room");
            entity.Property(e => e.IdGame).HasColumnName("ID_Game");

            entity.HasOne(d => d.IdGameNavigation).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.IdGame)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rooms_Games");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
