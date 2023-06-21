﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReviewApp.DAO;

#nullable disable

namespace ReviewApp.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20230618084534_AddGoodImage")]
    partial class AddGoodImage
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("goods.DAO.Models.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("GoodId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GoodId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("goods.DAO.Models.Good", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("EncodedFileImage")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TimeSpan")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Goods");
                });

            modelBuilder.Entity("goods.DAO.Models.Comment", b =>
                {
                    b.HasOne("goods.DAO.Models.Good", "Good")
                        .WithMany()
                        .HasForeignKey("GoodId");

                    b.Navigation("Good");
                });
#pragma warning restore 612, 618
        }
    }
}
