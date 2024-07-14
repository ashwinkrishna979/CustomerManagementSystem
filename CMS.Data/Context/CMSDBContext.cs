using Microsoft.EntityFrameworkCore;
using CMS.CoreBusiness.Models;


namespace CMS.Data.Context
{
    public class CMSDBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public CMSDBContext(DbContextOptions<CMSDBContext> options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("DefaultConnection", b => b.MigrationsAssembly("CMS.Web"));
            }
        }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}