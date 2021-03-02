using System;
using Invoice.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Infrastructure.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnName("IdUser");

            builder.Property(e => e.CreateDate).HasColumnType("date");

            builder.Property(e => e.DateBirth).HasColumnType("date");

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Names)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);

            builder.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false);

            builder.Property(e => e.UpdateDate).HasColumnType("date");
        }
    }
}
