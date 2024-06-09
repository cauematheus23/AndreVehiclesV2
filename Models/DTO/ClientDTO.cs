using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class ClientDTO : Person
    {
        public string DocumentDTO { get; set; }
        public decimal IncomeDTO { get; set; } 
    }
}
