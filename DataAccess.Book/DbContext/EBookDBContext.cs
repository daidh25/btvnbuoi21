using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataAccess.BookStore.DTO;
using DataAccess.Book.DTO;

namespace DataAccess.BookStore.DBContext
{
    public class EBookDBContext : DbContext
    {
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public EBookDBContext(DbContextOptions options) : base(options)
        {
        }
        public EBookDBContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Thiết lập chuỗi kết nối đến cơ sở dữ liệu SQL Server
                //BKS - 20240209BOY (trên lap)
                string connectionString = "Server=LAPTOP-GS7QPAK3\\SQLEXPRESS;Database=BanSach;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
                // Sử dụng SQL Server làm cơ sở dữ liệu
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}