using ErpSystemFeatureDAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystemFeatureDAL.Data.Context
{
    public class AppDbContext:DbContext
    {
        DbSet<Employee> Employees { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Calls> Calls { get; set; }

        public AppDbContext()
        { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
