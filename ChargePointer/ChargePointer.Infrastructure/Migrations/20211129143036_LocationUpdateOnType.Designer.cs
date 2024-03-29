﻿// <auto-generated />
using System;
using ChargePointer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChargePointer.Infrastructure.Migrations
{
    [DbContext(typeof(ChargePointerDbContext))]
    [Migration("20211129143036_LocationUpdateOnType")]
    partial class LocationUpdateOnType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChargePointer.Domain.Entities.ChargePoint", b =>
                {
                    b.Property<string>("ChargePointId")
                        .HasMaxLength(39)
                        .HasColumnType("nvarchar(39)");

                    b.Property<string>("FloorLevel")
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("LocationId")
                        .HasColumnType("nvarchar(39)");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("ChargePointId");

                    b.HasIndex("LocationId");

                    b.HasIndex("StatusId");

                    b.ToTable("ChargePoints");
                });

            modelBuilder.Entity("ChargePointer.Domain.Entities.Location", b =>
                {
                    b.Property<string>("LocationId")
                        .HasMaxLength(39)
                        .HasColumnType("nvarchar(39)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("ChargePointer.Domain.Entities.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            StatusId = 0,
                            Name = "Unknown"
                        },
                        new
                        {
                            StatusId = 1,
                            Name = "Available"
                        },
                        new
                        {
                            StatusId = 2,
                            Name = "Blocked"
                        },
                        new
                        {
                            StatusId = 3,
                            Name = "Charging"
                        },
                        new
                        {
                            StatusId = 4,
                            Name = "Removed"
                        },
                        new
                        {
                            StatusId = 5,
                            Name = "Reserved"
                        });
                });

            modelBuilder.Entity("ChargePointer.Domain.Entities.Type", b =>
                {
                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeId");

                    b.ToTable("Types");

                    b.HasData(
                        new
                        {
                            TypeId = 0,
                            Name = "Unknown"
                        },
                        new
                        {
                            TypeId = 1,
                            Name = "Parking"
                        },
                        new
                        {
                            TypeId = 2,
                            Name = "Airport"
                        },
                        new
                        {
                            TypeId = 3,
                            Name = "OnStreet"
                        });
                });

            modelBuilder.Entity("ChargePointer.Domain.Entities.ChargePoint", b =>
                {
                    b.HasOne("ChargePointer.Domain.Entities.Location", null)
                        .WithMany("ChargePoints")
                        .HasForeignKey("LocationId");

                    b.HasOne("ChargePointer.Domain.Entities.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("ChargePointer.Domain.Entities.Location", b =>
                {
                    b.Navigation("ChargePoints");
                });
#pragma warning restore 612, 618
        }
    }
}
