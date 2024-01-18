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
    public class CallConfiguration : IEntityTypeConfiguration<Calls>
    {
        public void Configure(EntityTypeBuilder<Calls> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.CallTitle)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.Property(i => i.Project)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();


            builder.Property(i => i.CallType)
                .HasColumnType("VARCHAR(50)");

            builder.Property(i => i.EmployeeName)
                .HasColumnType("VARCHAR(50)");

            builder.Property(i => i.Date)
                .HasColumnType("date");


            builder.HasOne(i => i.Customer)
               .WithMany(i => i.Calls)
               .HasForeignKey(i => i.CustomerId);

        }
    }
}
