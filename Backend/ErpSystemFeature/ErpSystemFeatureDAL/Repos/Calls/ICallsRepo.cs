﻿using ErpSystemFeatureDAL.Data.Models;
using ErpSystemFeatureDAL.Repos.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystemFeatureDAL
{
    public interface ICallsRepo:IGenericRepo<Calls>
    {
        List<Calls> GetAllPerPage(int page, int countPerPage);
        //For Pagination
        int GetCount();
    }
}
