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
    [Migration("20240211175107_AddFKRelation")]
    partial class AddFKRelation
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

                    b.Property<int?>("SessionId")
                        .HasColumnType("int");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.ToTable("Catches");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2024, 2, 11, 18, 51, 7, 689, DateTimeKind.Local).AddTicks(8905),
                            Length = 50.0,
                            Species = "Perch",
                            Weight = 2.0
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2024, 2, 11, 18, 51, 7, 689, DateTimeKind.Local).AddTicks(8909),
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
                            Date = new DateTime(2024, 2, 11, 18, 51, 7, 689, DateTimeKind.Local).AddTicks(8796),
                            Latitude = 51.98807,
                            Longitude = 6.0045200000000003
                        },
                        new
                        {
                            Id = 11,
                            Date = new DateTime(2024, 2, 11, 18, 51, 7, 689, DateTimeKind.Local).AddTicks(8826),
                            Latitude = 52.98807,
                            Longitude = 6.2045199999999996
                        });
                });

            modelBuilder.Entity("CatchMore.Models.Catch", b =>
                {
                    b.HasOne("CatchMore.Models.Session", "Session")
                        .WithMany()
                        .HasForeignKey("SessionId");

                    b.Navigation("Session");
                });
#pragma warning restore 612, 618
        }
    }
}
