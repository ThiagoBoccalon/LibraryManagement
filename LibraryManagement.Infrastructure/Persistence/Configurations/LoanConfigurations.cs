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
    public class LoanConfigurations : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder
                .HasKey(l => l.Id);

            builder
                .HasOne(u => u.User)
                .WithMany()
                .HasForeignKey(u => u.IdUser)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(b => b.Book)
                .WithMany()
                .HasForeignKey(b => b.IdBook)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
