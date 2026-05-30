using MFO_Logistics_API.Models;
using Microsoft.EntityFrameworkCore;

namespace MFO_Logistics_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Receipt> ReceiptReports { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("tbl_User").HasKey(x => x.UserID);

            modelBuilder.Entity<Receipt>().ToTable("tbl_Receipt").HasKey(x => x.ReceiptId);

            base.OnModelCreating(modelBuilder);

        }
    }
}
