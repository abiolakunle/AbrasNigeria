using AbrasNigeria.Models;
using Microsoft.EntityFrameworkCore;


namespace AbrasNigeria.Data.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Machine> Machines { get; set; }

        public DbSet<MachineType> MachineTypes { get; set; }

        public DbSet<Section> Sections { get; set; }

        public DbSet<SectionGroup> SectionGroups { get; set; }

        public DbSet<Document> Documents { get; set; }

        public DbSet<DocumentItem> DocumentItems { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Machine>().HasOne(m => m.Brand)
            //    .WithOne()
            //    .HasForeignKey<Brand>(b => b.BrandId);

            modelBuilder.Entity<ProductSectionGroup>().HasKey(psg => new { psg.ProductId, psg.SectionGroupId });

            modelBuilder.Entity<ProductMachine>().HasKey(pm => new { pm.ProductId, pm.MachineId });

            modelBuilder.Entity<MachineSection>().HasKey(ms => new { ms.MachineId, ms.SectionId });
            modelBuilder.Entity<MachineSectionGroup>().HasKey(msg => new { msg.MachineId, msg.SectionGroupId });

            modelBuilder.Entity<Document>()
            .Property(q => q.Date)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Order>()
                .Property(o => o.Date)
                .HasDefaultValueSql("getdate()");

            //modelBuilder.Entity<MachineSection>()
            //    .HasOne(m => m.Machine)
            //    .WithMany(m => m.MachineSections)
            //    .HasForeignKey(m => m.MachineId);

            //modelBuilder.Entity<MachineSection>()
            //    .HasOne(s => s.Section)
            //    .WithMany(s => s.MachineSections)
            //    .HasForeignKey(s => s.SectionId);

            //modelBuilder.Entity<Section>().HasMany(s => s.Machines);

            //modelBuilder.Entity<SectionGroup>().HasMany(s => s.Machines);

            //modelBuilder.Entity<Machine>().HasMany(m => m.Sections);

            //modelBuilder.Entity<Machine>().HasMany(m => m.SectionGroups);



        }
    }
}
