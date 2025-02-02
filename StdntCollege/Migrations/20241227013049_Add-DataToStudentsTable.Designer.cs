﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StdntCollege.Data;

#nullable disable

namespace StdntCollege.Migrations
{
    [DbContext(typeof(SchDbContext))]
    [Migration("20241227013049_Add-DataToStudentsTable")]
    partial class AddDataToStudentsTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StdntCollege.Data.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("StudentAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DOB = new DateTime(2024, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentAddress = "Festac1",
                            StudentEmail = "ireolu@gmail.com",
                            StudentName = "IreOlu"
                        },
                        new
                        {
                            Id = 2,
                            DOB = new DateTime(2025, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentAddress = "Festac2",
                            StudentEmail = "ireoba@gmail.com",
                            StudentName = "IreOba"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
