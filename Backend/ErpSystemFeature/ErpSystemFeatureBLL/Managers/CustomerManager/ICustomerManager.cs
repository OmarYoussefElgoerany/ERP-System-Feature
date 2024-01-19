using ErpSystemFeatureBLL.DTOs.CustomerDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystemFeatureBLL.Managers.EmployeeManager
{
    public interface ICustomerManager
    {
        List<ReadCustomerDto>? GetAll();

        List<ReadCustomerDto>? GetAllPerPage(int page, int countPerPage);

        bool isAdded(AddCustomerDto customerDto);

        bool isUpdated(ReadCustomerDto customerDto);

        bool isDeleted (int id);

    }
}
