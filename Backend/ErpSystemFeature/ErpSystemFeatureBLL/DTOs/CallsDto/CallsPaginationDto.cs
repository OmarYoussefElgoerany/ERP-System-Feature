using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystemFeatureBLL.DTOs.CallsDto
{
    public class CallsPaginationDto
    {
        public List<ReadCallsDto> ReadCallsDto { get; set; } = new List<ReadCallsDto>();
        public int Count { get; set; }
    }
}
