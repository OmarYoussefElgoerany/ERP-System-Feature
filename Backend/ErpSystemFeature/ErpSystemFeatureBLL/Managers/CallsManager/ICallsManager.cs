using ErpSystemFeatureBLL.DTOs.CallsDto;
using ErpSystemFeatureBLL.DTOs.CustomerDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystemFeatureBLL.Managers.CallsManager
{
    public interface ICallsManager
    {
        List<ReadCallsDto>? GetAll();

        List<ReadCallsDto>? GetAllPerPage(int page, int countPerPage);

        bool isAdded(AddCallsDto callsDto);

    }
}
