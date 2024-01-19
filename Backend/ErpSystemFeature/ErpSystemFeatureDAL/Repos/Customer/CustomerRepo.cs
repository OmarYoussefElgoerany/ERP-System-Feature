using ErpSystemFeatureDAL.Data.Context;
using ErpSystemFeatureDAL.Data.Models;
using ErpSystemFeatureDAL.Repos.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystemFeatureDAL
{
    public class CustomerRepo : GenericRepo<Customer>, ICustomerRepo
    {
        private readonly AppDbContext dbContext;

        public CustomerRepo(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Customer> GetAllPerPage(int page, int countPerPage)
        {
            return dbContext.Set<Customer>().
                OrderBy(i => i.Id)
               .Skip((page - 1) * countPerPage)
               .Take(countPerPage).ToList();
        }

        public int GetCount() => dbContext.Set<Customer>().Count();
    }
}
