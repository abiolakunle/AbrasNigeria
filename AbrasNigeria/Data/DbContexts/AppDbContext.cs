using AbrasNigeria.Models;
using Microsoft.EntityFrameworkCore;


namespace AbrasNigeria.Data.DbContexts
{
    public class AppDbContext : DbContext, IDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Document> Documents { get; set; }

        public DbSet<DocumentItem> DocumentItems { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<StockProduct> StockProducts { get; set; }

        public DbSet<StockProductHistory> StockProductHistories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Document>()
            .Property(q => q.Date)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Order>()
                .Property(o => o.Date)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<StockProductHistory>()
                .Property(p => p.Date)
                .HasDefaultValueSql("getDate()");
        }
    }
}
