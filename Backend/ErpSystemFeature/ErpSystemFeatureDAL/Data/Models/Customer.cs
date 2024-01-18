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
        public string Address { get; set; } = string.Empty;
        public string Residance { get; set; } = string.Empty;
        public string Job { get; set; } = string.Empty;
        public int Mobile { get; set; }
        public int Whatsapp { get; set; }
        public string Nationality { get; set; } = string.Empty;
        public DateTime DateAdded { get; set; }
        public DateTime LastEdit { get; set; }
        public string CustomerRating { get; set; }= string.Empty;
        public int? CustomerId { get; set; }
    }
}
