using Spotify.core.abstracts;
using SpotifyClone.Core.dtos.PaymentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Core.abstracts
{
    public interface IPaymentRepository : IRepository<PaymentDto>
    {
    }
}
