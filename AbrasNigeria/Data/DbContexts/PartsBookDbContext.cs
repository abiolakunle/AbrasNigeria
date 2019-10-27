using AbrasNigeria.Models;
using Microsoft.EntityFrameworkCore;

namespace AbrasNigeria.Data.DbContexts
{
    public class PartsBookDbContext : DbContext, IDbContext
    {
        public PartsBookDbContext(DbContextOptions<PartsBookDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Description> Descriptions { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Machine> Machines { get; set; }

        public DbSet<Section> Sections { get; set; }

        public DbSet<SectionGroup> SectionGroups { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Brand>().HasIndex(b => b.Name).IsUnique();
            modelBuilder.Entity<Machine>().HasIndex(m => m.ModelName).IsUnique();
            modelBuilder.Entity<Product>().HasIndex(p => p.PartNumber).IsUnique();
            modelBuilder.Entity<Description>().HasIndex(d => d.DescriptionName).IsUnique();
            modelBuilder.Entity<Section>().HasIndex(s => s.SectionName).IsUnique();
            modelBuilder.Entity<SectionGroup>().HasIndex(s => s.SectionGroupName).IsUnique();

            //modelBuilder.Entity<ProductSectionGroup>().HasKey(psg => new { psg.ProductId, psg.SectionGroupId });

            //modelBuilder.Entity<MachineSectionGroupProduct>().HasKey(pm => new { pm.ProductId, pm.MachineId, pm.SectionGroupId });

            //modelBuilder.Entity<MachineSection>().HasKey(ms => new { ms.MachineId, ms.SectionId });

            //modelBuilder.Entity<MachineSectionGroup>().HasKey(msg => new { msg.MachineId, msg.SectionGroupId });

            //modelBuilder.Entity<ProductDescription>().HasKey(pd => new { pd.ProductId, pd.DescriptionId });
        }
    }
}
