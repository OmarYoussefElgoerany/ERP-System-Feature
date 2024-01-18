using ErpSystemFeatureDAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystemFeatureDAL.Data.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name)
                 .HasColumnType("VARCHAR(50)")
                 .IsRequired();

            builder.Property(i => i.Title)
                    .HasColumnType("VARCHAR(50)")
                    .IsRequired();

            builder.HasMany(i => i.Customers)
                .WithOne(i => i.Employee)
                .HasForeignKey(i => i.EmployeeId);

        }
    }
}
