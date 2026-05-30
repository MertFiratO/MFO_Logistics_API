using MFO_Logistics_API.Models.Entities;
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
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ReceiptSearch> ReceiptSearchs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("tbl_User").HasKey(x => x.UserID);

            modelBuilder.Entity<Receipt>().ToTable("tbl_Receipt").HasKey(x => x.ReceiptId);

            modelBuilder.Entity<ReceiptSearch>().ToView("V_ReceiptSearch").HasNoKey();

            base.OnModelCreating(modelBuilder);

        }
    }
}
