using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Client : Person
    {
        public static readonly string SELECT = "SELECT p.Document, p.Name, p.BirthDate, p.Phone, p.Email, c.Income, a.Id, a.Street, a.ZipCode, a.Complement, a.State,a.Neighborhood, a.City,a.Number FROM Client c INNER JOIN Person p on c.Document = p.Document INNER JOIN Adress a on a.Id = p.AdressId";
                    
        public Decimal Income { get; set; }

        public Client()
        {
            
        }
        public Client(ClientDTO clientDTO)
        {
            this.Document = clientDTO.DocumentDTO;
            this.Name = clientDTO.Name;
            this.BirthDate = clientDTO.BirthDate;
            this.Phone = clientDTO.Phone;
            this.Email = clientDTO.Email;
            this.Income = clientDTO.IncomeDTO;
        }
    }
}
