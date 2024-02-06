﻿// <auto-generated />
using System;
using CatchMore.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CatchMore.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240202090958_Added-CatchModel")]
    partial class AddedCatchModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CatchMore.Models.Catch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("Length")
                        .HasColumnType("float");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Catches");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2024, 2, 2, 10, 9, 58, 500, DateTimeKind.Local).AddTicks(4217),
                            Length = 50.0,
                            Species = "Perch",
                            Weight = 2.0
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2024, 2, 2, 10, 9, 58, 500, DateTimeKind.Local).AddTicks(4220),
                            Length = 45.0,
                            Species = "Perch",
                            Weight = 1.5
                        });
                });

            modelBuilder.Entity("CatchMore.Models.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Sessions");

                    b.HasData(
                        new
                        {
                            Id = 10,
                            Date = new DateTime(2024, 2, 2, 10, 9, 58, 500, DateTimeKind.Local).AddTicks(4051),
                            Latitude = 51.98807,
                            Longitude = 6.0045200000000003
                        },
                        new
                        {
                            Id = 11,
                            Date = new DateTime(2024, 2, 2, 10, 9, 58, 500, DateTimeKind.Local).AddTicks(4082),
                            Latitude = 52.98807,
                            Longitude = 6.2045199999999996
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
