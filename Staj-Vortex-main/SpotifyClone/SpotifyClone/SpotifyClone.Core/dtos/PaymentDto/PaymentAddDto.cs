using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Core.dtos.PaymentDto
{
    public class PaymentAddDto
    {
        public int userId { get; set; }
        public int membershipTypeId { get; set; }
        public string cardNo { get; set; }
        public string cvc { get; set; }
       
    }
}
