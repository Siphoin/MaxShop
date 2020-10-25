﻿// <auto-generated />
using System;
using MaxShop.Delta;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MaxShop.Migrations
{
    [DbContext(typeof(AppDbContent))]
    [Migration("20201024140619_Order")]
    partial class Orders
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MaxShop.Delta.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("MaxShop.Delta.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("MaxShop.Delta.Models.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OrderId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderId1")
                        .HasColumnType("int");

                    b.Property<int>("PhoneId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId1");

                    b.HasIndex("PhoneId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("MaxShop.Delta.Models.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Avaliable")
                        .HasColumnType("bit");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("bit");

                    b.Property<string>("LongDecription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("ShortDecription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryID");

                    b.ToTable("Phone");
                });

            modelBuilder.Entity("MaxShop.Delta.Models.ShopPhoneItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("ShopCartId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("phoneId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("phoneId");

                    b.ToTable("ShopPhoneItem");
                });

            modelBuilder.Entity("MaxShop.Delta.Models.OrderDetail", b =>
                {
                    b.HasOne("MaxShop.Delta.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId1");

                    b.HasOne("MaxShop.Delta.Models.Phone", "Phone")
                        .WithMany()
                        .HasForeignKey("PhoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MaxShop.Delta.Models.Phone", b =>
                {
                    b.HasOne("MaxShop.Delta.Models.Category", "Category")
                        .WithMany("Phones")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MaxShop.Delta.Models.ShopPhoneItem", b =>
                {
                    b.HasOne("MaxShop.Delta.Models.Phone", "phone")
                        .WithMany()
                        .HasForeignKey("phoneId");
                });
#pragma warning restore 612, 618
        }
    }
}
