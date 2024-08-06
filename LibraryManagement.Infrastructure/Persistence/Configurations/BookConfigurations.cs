using LibraryManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Infrastructure.Persistence.Configurations
{
    public class BookConfigurations : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder.Property(b => b.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(b => b.Author)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(b => b.ISBN)
                .HasMaxLength(16)
                .IsRequired();
        }
    }
}
