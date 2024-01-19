using ErpSystemFeatureBLL.DTOs.EmployeeDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystemFeatureBLL.Managers.CustomerManager
{
    public interface IEmployeeManager
    {
        EmployeeDto? GetById(int id);

        List<EmployeeDto>? GetAll();
    }
}
