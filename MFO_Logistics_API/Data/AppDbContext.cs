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

        public DbSet<ReceiptReport> ReceiptReports { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReceiptReport>()
                .HasNoKey().ToView("V_ReceiptReport");

            base.OnModelCreating(modelBuilder);
        }
    }
}
