using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystemFeatureDAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        public ICustomerRepo customerRepo  { get; }

        public ICallsRepo callsRepo { get; }

        public IEmployeeRepo employeeRepo { get; }

        int SaveChanges();
    }
}
