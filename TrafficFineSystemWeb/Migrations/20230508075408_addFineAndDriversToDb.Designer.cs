﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrafficFineSystemWeb.Data;

#nullable disable

namespace TrafficFineSystemWeb.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230508075408_addFineAndDriversToDb")]
    partial class addFineAndDriversToDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TrafficFineSystemWeb.Models.DriversModel", b =>
                {
                    b.Property<string>("VechileNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicenseNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VechineType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VechileNumber");

                    b.ToTable("DriversAds");
                });

            modelBuilder.Entity("TrafficFineSystemWeb.Models.FineModel", b =>
                {
                    b.Property<int>("FineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FineId"), 1L, 1);

                    b.Property<string>("Amount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DriverId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FineType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicenseNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrafficId")
                        .HasColumnType("int");

                    b.Property<string>("VehicleNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FineId");

                    b.HasIndex("DriverId");

                    b.HasIndex("TrafficId");

                    b.ToTable("FineModels");
                });

            modelBuilder.Entity("TrafficFineSystemWeb.Models.TrafficModel", b =>
                {
                    b.Property<int>("TrafficId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrafficId"), 1L, 1);

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Post")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrafficId");

                    b.ToTable("TrafficAds");
                });

            modelBuilder.Entity("TrafficFineSystemWeb.Models.FineModel", b =>
                {
                    b.HasOne("TrafficFineSystemWeb.Models.DriversModel", "DriversAdd")
                        .WithMany()
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrafficFineSystemWeb.Models.TrafficModel", "TrafficAdd")
                        .WithMany()
                        .HasForeignKey("TrafficId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DriversAdd");

                    b.Navigation("TrafficAdd");
                });
#pragma warning restore 612, 618
        }
    }
}