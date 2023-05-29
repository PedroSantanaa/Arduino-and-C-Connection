﻿// <auto-generated />
using Arduino_DB.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Arduino_DB.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230528231405_DbSet")]
    partial class DbSet
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("Arduino_DB.modules.Arduino", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("corrente")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("temp")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("tensao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ArduinoData");
                });
#pragma warning restore 612, 618
        }
    }
}
