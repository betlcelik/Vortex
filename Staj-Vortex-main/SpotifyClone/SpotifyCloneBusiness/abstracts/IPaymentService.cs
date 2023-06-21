
using SpotifyClone.Core.dtos.PaymentDto;
using SpotifyClone.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Business.abstracts
{
    public interface IPaymentService
    {
        IResult Insert(PaymentDto paymentDto);
    }
}
