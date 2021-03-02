using System;
using Invoice.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Infrastructure.Data.Configuration
{
    public class SalesInvoiceProductsConfiguration : IEntityTypeConfiguration<SalesInvoiceProducts>
    {
        public SalesInvoiceProductsConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<SalesInvoiceProducts> builder)
        {
            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnName("IdSalesInvoiceProduct");

            builder.Property(e => e.CreateDate).HasColumnType("date");

            builder.Property(e => e.TotalValue).HasColumnType("decimal(18, 10)");

            builder.Property(e => e.UnitValue).HasColumnType("decimal(18, 10)");

            builder.Property(e => e.UpdateDate).HasColumnType("date");

            builder.HasOne(d => d.IdProductNavigation)
                .WithMany(p => p.SalesInvoiceProducts)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductId");

            builder.HasOne(d => d.IdSalesInvoiceNavigation)
                .WithMany(p => p.SalesInvoiceProducts)
                .HasForeignKey(d => d.IdSalesInvoice)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_InvoiceId");
        }
    }
}
