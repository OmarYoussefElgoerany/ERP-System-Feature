using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystemFeatureBLL.DTOs.CallsDto
{
    public class ReadCallsDto
    {
        public int Id { get; set; }
        public string CallTitle { get; set; } = string.Empty;
        public string Project { get; set; } = string.Empty;
        public string? EmployeeName { get; set; }
        public string? CallType { get; set; }
        public DateTime? Date { get; set; }
        public bool? isDone { get; set; }
        public int? CustomerId { get; set; }
    }
}
