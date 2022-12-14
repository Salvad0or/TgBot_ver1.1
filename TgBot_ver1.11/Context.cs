using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TgBot_ver1._11.EntityClasses;

namespace TgBot_ver1._11
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<CarCharacteristic> CarCharacteristics { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<ClientBankAccout> ClientBankAccouts { get; set; } = null!;
        public virtual DbSet<ClientStatus> ClientStatuses { get; set; } = null!;
        public virtual DbSet<RialDataBase> RialDatabases { get; set; } = null!;
        public virtual DbSet<Bot> Bots { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;DataBase=ITVDN2db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Cyrillic_General_CI_AS");

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Car");

                entity.Property(e => e.CarName).HasMaxLength(50);

                entity.Property(e => e.Vin)
                    .HasMaxLength(50)
                    .HasColumnName("VIN");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Car__ClientId__0E04126B");
            });

            modelBuilder.Entity<CarCharacteristic>(entity =>
            {
                entity.HasIndex(e => e.CarId, "UQ__CarChara__68A0342F0DF02FB1")
                    .IsUnique();

                entity.Property(e => e.AirFilter).HasMaxLength(50);

                entity.Property(e => e.FuelFilter).HasMaxLength(50);

                entity.Property(e => e.Oil).HasMaxLength(50);

                entity.Property(e => e.OilFilter).HasMaxLength(50);

                entity.Property(e => e.PadsFront).HasMaxLength(50);

                entity.Property(e => e.PadsRear).HasMaxLength(50);

                entity.Property(e => e.SalonFilter).HasMaxLength(50);

                entity.Property(e => e.Сandles).HasMaxLength(50);
        
                entity.HasOne(d => d.Car)
                    .WithOne(p => p.CarCharacteristic)
                    .HasForeignKey<CarCharacteristic>(d => d.CarId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__CarCharac__CarId__10E07F16");
            });


            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.HasIndex(e => e.Phone, "UQ__Client__5C7E359E1541BBAE")
                    .IsUnique();

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Fname).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Client__StatusID__7EC1CEDB");
            });

            modelBuilder.Entity<ClientBankAccout>(entity =>
            {
                entity.ToTable("ClientBankAccout");

                entity.HasIndex(e => e.ClientId, "UQ__ClientBa__E67E1A25C67D7BCE")
                    .IsUnique();

                entity.Property(e => e.CashBack).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TotalPurchaseAmount).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Client)
                    .WithOne(p => p.ClientBankAccout)        
                    .HasForeignKey<ClientBankAccout>(d => d.ClientId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__ClientBan__Clien__02925FBF");


            });

            modelBuilder.Entity<ClientStatus>(entity =>
            {
                entity.ToTable("ClientStatus");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Status).HasMaxLength(30);
            });

            modelBuilder.Entity<RialDataBase>(entity =>
            {
                entity.ToTable("RialDataBase");

                entity.Property(e => e.AirFilter).HasMaxLength(50);

                entity.Property(e => e.Car).HasMaxLength(50);

                entity.Property(e => e.Comment).HasMaxLength(200);

                entity.Property(e => e.Dates).HasMaxLength(30);

                entity.Property(e => e.Fuelfilter).HasMaxLength(50);

                entity.Property(e => e.Names).HasMaxLength(50);

                entity.Property(e => e.Ngk).HasMaxLength(50);

                entity.Property(e => e.Oil).HasMaxLength(50);

                entity.Property(e => e.OilFilter).HasMaxLength(50);

                entity.Property(e => e.Padsfront).HasMaxLength(50);

                entity.Property(e => e.Padsrear).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.SalonFilter).HasMaxLength(50);

                entity.Property(e => e.Statuss).HasMaxLength(20);

                entity.Property(e => e.Vin)
                    .HasMaxLength(20)
                    .HasColumnName("vin");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
