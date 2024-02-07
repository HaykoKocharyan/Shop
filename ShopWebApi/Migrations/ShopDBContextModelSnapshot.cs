﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Shop.Repo.Repositories;

#nullable disable

namespace ShopWebApi.Migrations
{
    [DbContext(typeof(ShopDBContext))]
    partial class ShopDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Shop.Repo.Entities.Good", b =>
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("Supplier_Id")
                        .HasColumnType("integer");

                    b.Property<double?>("Weight_KG")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("Supplier_Id");

                    b.ToTable("Goods");
                });

            modelBuilder.Entity("Shop.Repo.Entities.ReturnedGood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<int?>("Quantity")
                        .HasColumnType("integer");

                    b.Property<string>("Reason")
                        .HasColumnType("text");

                    b.Property<decimal>("Refund_Amount")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("Return_Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("now()");

                    b.Property<int>("SoldGood_Id")
                        .HasColumnType("integer");

                    b.Property<double?>("Weight_Kg")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("SoldGood_Id");

                    b.ToTable("ReturnedGoods");
                });

            modelBuilder.Entity("Shop.Repo.Entities.SoldGood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("now()");

                    b.Property<int>("Goods_Id")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int?>("Quantity")
                        .HasColumnType("integer");

                    b.Property<decimal>("Total_Price")
                        .HasColumnType("numeric");

                    b.Property<double?>("Weight_KG")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("Goods_Id");

                    b.ToTable("SoldGoods");
                });

            modelBuilder.Entity("Shop.Repo.Entities.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Contact_Person")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created_Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Shop.Repo.Entities.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Last_Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Position")
                        .HasColumnType("text");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("Work_End_Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Work_Start_Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("Shop.Repo.Entities.Good", b =>
                {
                    b.HasOne("Shop.Repo.Entities.Supplier", "Supplier")
                        .WithMany("Goods")
                        .HasForeignKey("Supplier_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Shop.Repo.Entities.ReturnedGood", b =>
                {
                    b.HasOne("Shop.Repo.Entities.SoldGood", "SoldGood")
                        .WithMany()
                        .HasForeignKey("SoldGood_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SoldGood");
                });

            modelBuilder.Entity("Shop.Repo.Entities.SoldGood", b =>
                {
                    b.HasOne("Shop.Repo.Entities.Good", "Goods")
                        .WithMany()
                        .HasForeignKey("Goods_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Goods");
                });

            modelBuilder.Entity("Shop.Repo.Entities.Supplier", b =>
                {
                    b.Navigation("Goods");
                });
#pragma warning restore 612, 618
        }
    }
}
