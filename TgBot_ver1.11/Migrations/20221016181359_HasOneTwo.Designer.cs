// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TgBot_ver1._11;

#nullable disable

namespace TgBot_ver1._11.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20221016181359_HasOneTwo")]
    partial class HasOneTwo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("Cyrillic_General_CI_AS")
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TgBot_ver1._11.EntityClasses.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CarName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Vin")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("VIN");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Car", (string)null);
                });

            modelBuilder.Entity("TgBot_ver1._11.EntityClasses.CarCharacteristic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AirFilter")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("FuelFilter")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Oil")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OilFilter")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PadsFront")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PadsRear")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SalonFilter")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Сandles")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CarId" }, "UQ__CarChara__68A0342F0DF02FB1")
                        .IsUnique()
                        .HasFilter("[CarId] IS NOT NULL");

                    b.ToTable("CarCharacteristics");
                });

            modelBuilder.Entity("TgBot_ver1._11.EntityClasses.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Fname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .IsUnicode(false)
                        .HasColumnType("varchar(11)");

                    b.Property<byte?>("StatusId")
                        .HasColumnType("tinyint")
                        .HasColumnName("StatusID");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.HasIndex(new[] { "Phone" }, "UQ__Client__5C7E359E1541BBAE")
                        .IsUnique();

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("TgBot_ver1._11.EntityClasses.ClientBankAccout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal?>("CashBack")
                        .HasColumnType("decimal(18,0)");

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<decimal?>("TotalPurchaseAmount")
                        .HasColumnType("decimal(18,0)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ClientId" }, "UQ__ClientBa__E67E1A25C67D7BCE")
                        .IsUnique()
                        .HasFilter("[ClientId] IS NOT NULL");

                    b.ToTable("ClientBankAccout", (string)null);
                });

            modelBuilder.Entity("TgBot_ver1._11.EntityClasses.ClientStatus", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<byte>("Id"), 1L, 1);

                    b.Property<string>("Status")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("ClientStatus", (string)null);
                });

            modelBuilder.Entity("TgBot_ver1._11.EntityClasses.RialDataBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AirFilter")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Car")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("CashBack")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Dates")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Fuelfilter")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Names")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Ngk")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Oil")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OilFilter")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Padsfront")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Padsrear")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SalonFilter")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Statuss")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("TotalPurchaseAmount")
                        .HasColumnType("int");

                    b.Property<string>("Vin")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("vin");

                    b.HasKey("Id");

                    b.ToTable("RialDataBase", (string)null);
                });

            modelBuilder.Entity("TgBot_ver1._11.EntityClasses.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("NameTest")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.ToTable("Test", (string)null);
                });

            modelBuilder.Entity("TgBot_ver1._11.EntityClasses.Car", b =>
                {
                    b.HasOne("TgBot_ver1._11.EntityClasses.Client", "Client")
                        .WithMany("Cars")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__Car__ClientId__0E04126B");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("TgBot_ver1._11.EntityClasses.CarCharacteristic", b =>
                {
                    b.HasOne("TgBot_ver1._11.EntityClasses.Car", "Car")
                        .WithOne("CarCharacteristic")
                        .HasForeignKey("TgBot_ver1._11.EntityClasses.CarCharacteristic", "CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__CarCharac__CarId__10E07F16");

                    b.Navigation("Car");
                });

            modelBuilder.Entity("TgBot_ver1._11.EntityClasses.Client", b =>
                {
                    b.HasOne("TgBot_ver1._11.EntityClasses.ClientStatus", "Status")
                        .WithMany("Clients")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__Client__StatusID__7EC1CEDB");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("TgBot_ver1._11.EntityClasses.ClientBankAccout", b =>
                {
                    b.HasOne("TgBot_ver1._11.EntityClasses.Client", "Client")
                        .WithOne("ClientBankAccout")
                        .HasForeignKey("TgBot_ver1._11.EntityClasses.ClientBankAccout", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__ClientBan__Clien__02925FBF");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("TgBot_ver1._11.EntityClasses.Test", b =>
                {
                    b.HasOne("TgBot_ver1._11.EntityClasses.Client", "Client")
                        .WithOne("Test")
                        .HasForeignKey("TgBot_ver1._11.EntityClasses.Test", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("TgBot_ver1._11.EntityClasses.Car", b =>
                {
                    b.Navigation("CarCharacteristic");
                });

            modelBuilder.Entity("TgBot_ver1._11.EntityClasses.Client", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("ClientBankAccout");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("TgBot_ver1._11.EntityClasses.ClientStatus", b =>
                {
                    b.Navigation("Clients");
                });
#pragma warning restore 612, 618
        }
    }
}
