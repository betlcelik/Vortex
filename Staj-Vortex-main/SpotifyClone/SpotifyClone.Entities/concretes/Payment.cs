using SpotifyClone.Entities.abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Entities.concretes
{
    public class Payment : IPayment
    {
        public int id { get; set;}
        public int userId { get; set; }
        public int membershipTypeId { get; set; }
        public string cardNo { get; set; }
        public string cvc { get; set; }
        public DateTime paymentDate { get; set; }
        public double price { get; set; }
        public string state { get; set; }
    }
}
