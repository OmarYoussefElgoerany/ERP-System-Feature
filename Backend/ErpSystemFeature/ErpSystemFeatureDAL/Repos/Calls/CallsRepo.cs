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
    public class CallsRepo : GenericRepo<Calls>, ICallsRepo
    {
        private readonly AppDbContext dbContext;

        public CallsRepo(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Calls> GetAllPerPage(int page, int countPerPage)
        {
            return dbContext.Set<Calls>()
               .Skip((page - 1) * countPerPage)
               .Take(countPerPage).ToList();
        }
    }
}
