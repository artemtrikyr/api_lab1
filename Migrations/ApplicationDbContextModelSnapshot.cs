﻿// <auto-generated />
using System;
using AttendanceJournalApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api_lab1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AttendanceJournalApi.Models.AttendanceRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Discipline")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("LessonDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Student")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Teacher")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("WasPresent")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("AttendanceRecords");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Discipline = "Mathematics",
                            Group = "CS101",
                            LessonDate = new DateTime(2024, 4, 1, 9, 0, 0, 0, DateTimeKind.Utc),
                            Student = "John Doe",
                            Teacher = "Dr. Smith",
                            WasPresent = true
                        },
                        new
                        {
                            Id = 2,
                            Discipline = "Physics",
                            Group = "CS102",
                            LessonDate = new DateTime(2025, 3, 1, 9, 0, 0, 0, DateTimeKind.Utc),
                            Student = "Jane Smith",
                            Teacher = "Dr. Brown",
                            WasPresent = false
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
