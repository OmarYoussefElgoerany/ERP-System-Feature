using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystemFeatureDAL.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Job { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? Residance { get; set; }
        public int Mobile { get; set; }
        public int? Whatsapp { get; set; }
        public string? Nationality { get; set; }
        public DateTime? DateAdded { get; set; } = DateTime.Now;
        public DateTime? LastEdit { get; set; } = DateTime.Now;
        public string? CustomerRating { get; set; }
        public int? EmployeeId { get; set; }

        public virtual List<Calls> Calls { get; set; } = new List<Calls>();
        public Employee? Employee { get; set; }
    }
}
