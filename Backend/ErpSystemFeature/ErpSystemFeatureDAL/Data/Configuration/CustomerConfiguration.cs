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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
              builder.HasKey(i => i.Id);

              builder.Property(i => i.Name)
                  .HasColumnType("VARCHAR(50)")
                  .IsRequired();

              builder.Property(i => i.Job)
                  .HasColumnType("VARCHAR(50)")
                  .IsRequired();


            builder.Property(i => i.DateAdded)
                 .HasColumnType("date");


            builder.Property(i => i.LastEdit)
                .HasColumnType("date");

            builder.Property(i => i.Address)
                    .HasColumnType("VARCHAR(50)");
             
              builder.Property(i => i.Residance)
                   .HasColumnType("VARCHAR(50)");
             
             
              builder.Property(i => i.Mobile)
                    .IsRequired();
             
              builder.Property(i => i.Nationality)
                 .HasColumnType("VARCHAR(50)");
             
              builder.Property(i => i.CustomerRating)
               .HasColumnType("VARCHAR(50)");

        }
    }
}
