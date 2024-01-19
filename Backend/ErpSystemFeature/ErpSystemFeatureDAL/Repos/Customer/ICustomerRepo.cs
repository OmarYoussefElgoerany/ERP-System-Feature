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
    public interface ICustomerRepo : IGenericRepo<Customer>
    {
        List<Customer> GetAllPerPage(int page, int countPerPage);
        //For Pagination
        int GetCount();

    }

}
