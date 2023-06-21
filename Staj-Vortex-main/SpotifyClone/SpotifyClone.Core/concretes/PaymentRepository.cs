using Spotify.core.concretes;
using Spotify.core.DbConnection.EntityFramework;
using SpotifyClone.Core.abstracts;
using SpotifyClone.Core.dtos.PaymentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Core.concretes
{
    public class PaymentRepository : Repository<PaymentDto>, IPaymentRepository
    {
        public PaymentRepository(DataBaseConnection context) : base(context)
        {
        }
    }
}
