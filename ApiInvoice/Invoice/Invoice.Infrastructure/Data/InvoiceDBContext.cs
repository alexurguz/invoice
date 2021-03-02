using Invoice.Core.Entities;
using Invoice.Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Infrastructure.Data
{
    public partial class InvoiceDBContext : DbContext
    {
        public InvoiceDBContext()
        {
        }

        public InvoiceDBContext(DbContextOptions<InvoiceDBContext> options) : base(options)
        {
        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<SalesInvoice> SalesInvoice { get; set; }
        public virtual DbSet<SalesInvoiceProducts> SalesInvoiceProducts { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            modelBuilder.ApplyConfiguration(new SalesInvoiceConfiguration());

            modelBuilder.ApplyConfiguration(new SalesInvoiceProductsConfiguration());

            modelBuilder.ApplyConfiguration(new UserConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
