﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrzelicznikMVVM.BazaDanych.Context;

namespace PrzelicznikMVVM.BazaDanych.Migrations
{
    [DbContext(typeof(ConverterDbContext))]
    partial class ConverterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("PrzelicznikMVVM.BazaDanych.Model.Converter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("UnitFromId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UnitToId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UnitFromId");

                    b.HasIndex("UnitToId");

                    b.ToTable("Converters");
                });

            modelBuilder.Entity("PrzelicznikMVVM.BazaDanych.Model.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CharRepresentation")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("TypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("PrzelicznikMVVM.BazaDanych.Model.UnitType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("UnitTypes");
                });

            modelBuilder.Entity("PrzelicznikMVVM.BazaDanych.Model.Converter", b =>
                {
                    b.HasOne("PrzelicznikMVVM.BazaDanych.Model.Unit", "UnitFrom")
                        .WithMany()
                        .HasForeignKey("UnitFromId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrzelicznikMVVM.BazaDanych.Model.Unit", "UnitTo")
                        .WithMany()
                        .HasForeignKey("UnitToId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UnitFrom");

                    b.Navigation("UnitTo");
                });

            modelBuilder.Entity("PrzelicznikMVVM.BazaDanych.Model.Unit", b =>
                {
                    b.HasOne("PrzelicznikMVVM.BazaDanych.Model.UnitType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });
#pragma warning restore 612, 618
        }
    }
}
