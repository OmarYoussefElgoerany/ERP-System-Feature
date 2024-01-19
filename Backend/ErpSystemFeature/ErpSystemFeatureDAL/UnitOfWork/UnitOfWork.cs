using ErpSystemFeatureDAL.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystemFeatureDAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext appDbContext;

        public ICustomerRepo customerRepo { get; }

        public ICallsRepo callsRepo { get; }

        public IEmployeeRepo employeeRepo { get; }

        public UnitOfWork
            (
            AppDbContext appDbContext,
            ICustomerRepo customerRepo ,
            ICallsRepo callsRepo,
            IEmployeeRepo employeeRepo
            )
        {
            this.callsRepo = callsRepo;
            this.appDbContext = appDbContext;
            this.customerRepo = customerRepo;
            this.employeeRepo = employeeRepo;
        }
        public int SaveChanges() => appDbContext.SaveChanges();
       
    }
}
