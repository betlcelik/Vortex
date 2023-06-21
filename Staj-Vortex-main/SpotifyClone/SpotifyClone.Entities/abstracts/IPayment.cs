using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Entities.abstracts
{
    public interface IPayment
    {
       
        [Key]
        public int id { get; set; }
        public int userId { get; set; }
        public int membershipTypeId { get; set; }
        public string cardNo { get; set; }
        public string cvc { get; set; }
        public DateTime paymentDate { get; set; }
        public double price { get; set; }
        public string state { get; set; }

    }
}
