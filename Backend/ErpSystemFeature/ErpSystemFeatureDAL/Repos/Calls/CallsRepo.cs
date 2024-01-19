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
    public class CallsRepo : GenericRepo<Calls>, ICallsRepo
    {
        public CallsRepo(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
