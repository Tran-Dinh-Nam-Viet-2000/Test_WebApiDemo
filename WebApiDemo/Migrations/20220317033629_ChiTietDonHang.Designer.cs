﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiDemo.Database;

namespace WebApiDemo.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20220317033629_ChiTietDonHang")]
    partial class ChiTietDonHang
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("WebApiDemo.Database.ChiTietDonhang", b =>
                {
                    b.Property<int>("MaDonHang")
                        .HasColumnType("int");

                    b.Property<int>("MaHangHoa")
                        .HasColumnType("int");

                    b.Property<double>("DonGia")
                        .HasColumnType("float");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("MaDonHang", "MaHangHoa");

                    b.HasIndex("MaHangHoa");

                    b.ToTable("ChiTietDonhang");
                });

            modelBuilder.Entity("WebApiDemo.Database.DonHang", b =>
                {
                    b.Property<int>("MaDonHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayDat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<DateTime?>("NgayGiao")
                        .HasColumnType("datetime2");

                    b.Property<string>("NguoiNhan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoDienThoai")
                        .HasColumnType("int");

                    b.Property<int>("TinhTrangDonHang")
                        .HasColumnType("int");

                    b.HasKey("MaDonHang");

                    b.ToTable("DonHang");
                });

            modelBuilder.Entity("WebApiDemo.Database.HangHoa", b =>
                {
                    b.Property<int>("MaHangHoa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double?>("GiaBan")
                        .HasColumnType("float");

                    b.Property<int?>("MaLoai")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenHangHoa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaHangHoa");

                    b.HasIndex("MaLoai");

                    b.ToTable("HangHoa");
                });

            modelBuilder.Entity("WebApiDemo.Database.Loai", b =>
                {
                    b.Property<int>("MaLoai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("TenLoai")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaLoai");

                    b.ToTable("Loai");
                });

            modelBuilder.Entity("WebApiDemo.Database.ChiTietDonhang", b =>
                {
                    b.HasOne("WebApiDemo.Database.DonHang", "DonHang")
                        .WithMany("ChiTietDonhangs")
                        .HasForeignKey("MaDonHang")
                        .HasConstraintName("FK_ChiTietDonHang_DonHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiDemo.Database.HangHoa", "HangHoa")
                        .WithMany("ChiTietDonhangs")
                        .HasForeignKey("MaHangHoa")
                        .HasConstraintName("FK_ChiTietDonHang_HangHoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonHang");

                    b.Navigation("HangHoa");
                });

            modelBuilder.Entity("WebApiDemo.Database.HangHoa", b =>
                {
                    b.HasOne("WebApiDemo.Database.Loai", "Loai")
                        .WithMany("HangHoas")
                        .HasForeignKey("MaLoai");

                    b.Navigation("Loai");
                });

            modelBuilder.Entity("WebApiDemo.Database.DonHang", b =>
                {
                    b.Navigation("ChiTietDonhangs");
                });

            modelBuilder.Entity("WebApiDemo.Database.HangHoa", b =>
                {
                    b.Navigation("ChiTietDonhangs");
                });

            modelBuilder.Entity("WebApiDemo.Database.Loai", b =>
                {
                    b.Navigation("HangHoas");
                });
#pragma warning restore 612, 618
        }
    }
}
