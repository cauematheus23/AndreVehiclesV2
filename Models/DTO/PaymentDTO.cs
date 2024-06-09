using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class PaymentDTO
    {
        
        public string CreditCard { get; set; }
        public int BoletoId { get; set; }
        public int PixId { get; set; }
        public DateTime PaymentDate { get; set; }

    }
}
