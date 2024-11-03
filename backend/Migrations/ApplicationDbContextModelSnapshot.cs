﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Data;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("shared.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrentState")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Equipment");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CurrentState = 0,
                            Name = "Molding Machine A"
                        },
                        new
                        {
                            Id = 2,
                            CurrentState = 1,
                            Name = "Molding Machine B"
                        },
                        new
                        {
                            Id = 3,
                            CurrentState = 2,
                            Name = "Molding Machine C"
                        },
                        new
                        {
                            Id = 4,
                            CurrentState = 0,
                            Name = "Assembly Line A"
                        },
                        new
                        {
                            Id = 5,
                            CurrentState = 1,
                            Name = "Assembly Line B"
                        },
                        new
                        {
                            Id = 6,
                            CurrentState = 2,
                            Name = "Assembly Line C"
                        },
                        new
                        {
                            Id = 7,
                            CurrentState = 0,
                            Name = "Packaging Unit A"
                        },
                        new
                        {
                            Id = 8,
                            CurrentState = 1,
                            Name = "Packaging Unit B"
                        },
                        new
                        {
                            Id = 9,
                            CurrentState = 2,
                            Name = "Packaging Unit C"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
