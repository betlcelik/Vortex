
using SpotifyClone.Business.abstracts;
using SpotifyClone.Core.abstracts;
using SpotifyClone.Core.dtos.PaymentDto;
using SpotifyClone.Core.Utilities.Results.Abstract;
using SpotifyClone.Core.Utilities.Results.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Business.concretes
{
    public class PaymentManager : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentManager(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public IResult Insert(PaymentDto paymentDto)
        {
            _paymentRepository.Insert(paymentDto);
            return new SuccessResult("Ödeme Bilgileri Eklendi");
        }
    }
}
