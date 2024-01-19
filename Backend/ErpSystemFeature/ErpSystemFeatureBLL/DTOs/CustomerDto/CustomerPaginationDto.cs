using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystemFeatureBLL.DTOs.CustomerDto
{
    public class CustomerPaginationDto
    {
        public List<ReadCustomerDto> CustomerDtos { get; set; } = new List<ReadCustomerDto>();
        public int TotalCount { get; set; }
    }
}
