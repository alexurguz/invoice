using Invoice.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Infrastructure.Data.Configuration
{
    public class SalesInvoiceConfiguration : IEntityTypeConfiguration<SalesInvoice>
    {
        public SalesInvoiceConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<SalesInvoice> builder)
        {
            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnName("IdSalesInvoice");

            builder.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.CreateDate).HasColumnType("date");

            builder.Property(e => e.DateSales).HasColumnType("date");

            builder.Property(e => e.Discount).HasColumnType("decimal(18, 10)");

            builder.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false);

            builder.Property(e => e.Total).HasColumnType("decimal(18, 10)");

            builder.Property(e => e.TotalWithoutDiscount).HasColumnType("decimal(18, 10)");

            builder.Property(e => e.UpdateDate).HasColumnType("date");

            builder.HasOne(d => d.IdCustomerNavigation)
                .WithMany(p => p.SalesInvoice)
                .HasForeignKey(d => d.IdCustomer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_CustomerId");
        }
    }
}
