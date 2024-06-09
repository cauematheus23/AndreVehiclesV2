using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Card
    {
        [Key]
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string DueDate { get; set; }
        public string Name { get; set; }
    }
}
