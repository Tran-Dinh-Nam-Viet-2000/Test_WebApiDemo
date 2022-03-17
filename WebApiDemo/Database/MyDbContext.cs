using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.Database
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {

        }

        #region Tạo các bảng để mapping với nhau
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<Loai> Loais { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<ChiTietDonhang> ChiTietDonhangs { get; set; }
        #endregion

        //Tạo ràng buộc cho các Entity
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Tạo cho DonHang
            modelBuilder.Entity<DonHang>(e =>
            {
               e.ToTable("DonHang"); //Tên Table
               e.HasKey(dh => dh.MaDonHang); //Khóa chính
               e.Property(dh => dh.NgayDat).HasDefaultValueSql("getutcdate()"); //Đặt ngày mặc định theo sql

            });
            //Tạo cho DonHang
            modelBuilder.Entity<ChiTietDonhang>(e =>
            {
                e.ToTable("ChiTietDonhang");
                //Do bên ChiTietDonhang map với 2 khóa chính nên khai báo cả 2
                e.HasKey(dh => new { dh.MaDonHang, dh.MaHangHoa});

                //Định nghĩa mối quan hệ 1 nhiều (1-N)
                //Vì ở ChiTietDonHang có khai báo 2 đối tượng DonHang và HangHoa nên chúng cần đc định nghĩa
                e.HasOne(entity => entity.DonHang) //Chỉ rõ tên đối tượng
                .WithMany(entity => entity.ChiTietDonhangs) //Từ đối tượng lấy ra được ChiTietDonhangs
                .HasForeignKey(entity => entity.MaDonHang) //Khóa ngoại
                .HasConstraintName("FK_ChiTietDonHang_DonHang"); //Đặt tên khóa ngoại (Có hoặc ko)

                e.HasOne(entity => entity.HangHoa)
                .WithMany(entity => entity.ChiTietDonhangs)
                .HasForeignKey(entity => entity.MaHangHoa)
                .HasConstraintName("FK_ChiTietDonHang_HangHoa");
            });
        }
    }
}
