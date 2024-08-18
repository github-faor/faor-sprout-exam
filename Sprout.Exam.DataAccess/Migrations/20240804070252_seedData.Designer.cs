﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sprout.Exam.DataAccess;

namespace Sprout.Exam.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240804070252_seedData")]
    partial class seedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sprout.Exam.DataAccess.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeTypeId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("TIN")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employee");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(2024, 8, 4, 15, 2, 51, 986, DateTimeKind.Local).AddTicks(7541),
                            EmployeeTypeId = 1,
                            FullName = "Fides Arianne Ramos",
                            IsDeleted = true,
                            TIN = "1234567890"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(2024, 8, 4, 15, 2, 51, 987, DateTimeKind.Local).AddTicks(6208),
                            EmployeeTypeId = 1,
                            FullName = "Employee 2",
                            IsDeleted = false,
                            TIN = "2345678901"
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTime(2024, 8, 4, 15, 2, 51, 987, DateTimeKind.Local).AddTicks(6223),
                            EmployeeTypeId = 2,
                            FullName = "Employee 3",
                            IsDeleted = false,
                            TIN = "3456789012"
                        },
                        new
                        {
                            Id = 4,
                            BirthDate = new DateTime(2024, 8, 4, 15, 2, 51, 987, DateTimeKind.Local).AddTicks(6225),
                            EmployeeTypeId = 1,
                            FullName = "Employee 4",
                            IsDeleted = false,
                            TIN = "4567890123"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
