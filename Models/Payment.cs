using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Payment
    {
        public int Id { get; set; }
        public Card Card { get; set; }
        public Boleto Boleto { get; set; }
        public Pix Pix { get; set; }
        public DateTime PaymentDate { get; set; }
        public Payment()
        {
            
        }
        public Payment(PaymentDTO DTO)
        {
            Card c = new Card { CardNumber = DTO.CreditCard };
            Boleto b = new Boleto { Number = DTO.BoletoId };
            Pix p = new Pix { Id = DTO.PixId };
            this.Card = c;
            this.Boleto = b;
            this.Pix = p;
            this.PaymentDate = DTO.PaymentDate;
        }
    }
}
