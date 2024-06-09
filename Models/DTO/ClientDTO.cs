using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class ClientDTO
    {
        public string Document { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public AdressDTO Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Decimal Income { get; set; } 
    }
}
