﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Shop.Repo.Repositories;

#nullable disable

namespace ShopWebApi.Migrations
{
    [DbContext(typeof(ShopDBContext))]
    [Migration("20231215121014_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Shop.Repo.Entities.Goods", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created_Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("now()");

                    b.Property<decimal>("Import_Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Product_Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Quantity")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<int>("Supplier_Id")
                        .HasColumnType("integer");

                    b.Property<double?>("Weight_KG")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("Supplier_Id");

                    b.ToTable("Goods");
                });

            modelBuilder.Entity("Shop.Repo.Entities.ReturnedGoods", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<int>("Goods_Id")
                        .HasColumnType("integer");

                    b.Property<int?>("Quantity_Returned")
                        .HasColumnType("integer");

                    b.Property<string>("Reason")
                        .HasColumnType("text");

                    b.Property<decimal?>("Refund_Amount")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("Return_Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("now()");

                    b.Property<double?>("Weight_Kg_Returned")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("Goods_Id");

                    b.ToTable("ReturnedGoods");
                });

            modelBuilder.Entity("Shop.Repo.Entities.SoldGoods", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<int>("Goods_Id")
                        .HasColumnType("integer");

                    b.Property<int?>("Quantity_Sold")
                        .HasColumnType("integer");

                    b.Property<decimal>("Sale_Price")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("Sold_Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("now()");

                    b.Property<decimal>("Total_Price")
                        .HasColumnType("numeric");

                    b.Property<double?>("Weight_Sold")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("Goods_Id");

                    b.ToTable("SoldGoods");
                });

            modelBuilder.Entity("Shop.Repo.Entities.Suppliers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("Contact_Person")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created_Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Supplier_Address")
                        .HasColumnType("text");

                    b.Property<string>("Supplier_Email")
                        .HasColumnType("text");

                    b.Property<string>("Supplier_Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Supplier_Phone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Shop.Repo.Entities.Workers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("Work_End_Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Work_Start_Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Worker_Adress")
                        .HasColumnType("text");

                    b.Property<string>("Worker_Email")
                        .HasColumnType("text");

                    b.Property<string>("Worker_LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Worker_Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Worker_Phone")
                        .HasColumnType("text");

                    b.Property<string>("Worker_Position")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("Worker_Salary")
                        .IsRequired()
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("Shop.Repo.Entities.Goods", b =>
                {
                    b.HasOne("Shop.Repo.Entities.Suppliers", "Supplier")
                        .WithMany()
                        .HasForeignKey("Supplier_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Shop.Repo.Entities.ReturnedGoods", b =>
                {
                    b.HasOne("Shop.Repo.Entities.Goods", "Goods")
                        .WithMany()
                        .HasForeignKey("Goods_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Goods");
                });

            modelBuilder.Entity("Shop.Repo.Entities.SoldGoods", b =>
                {
                    b.HasOne("Shop.Repo.Entities.Goods", "Goods")
                        .WithMany()
                        .HasForeignKey("Goods_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Goods");
                });
#pragma warning restore 612, 618
        }
    }
}