using ErpSystemFeatureDAL.Data.Context;
using ErpSystemFeatureDAL.Data.Models;
using ErpSystemFeatureDAL.Repos.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystemFeatureDAL
{
    public class EmployeeRepo: GenericRepo<Employee> , IEmployeeRepo
    {
        public EmployeeRepo(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
