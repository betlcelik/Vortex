
using AutoMapper.Execution;
using SpotifyClone.Business.abstracts;
using SpotifyClone.Core.abstracts;
using SpotifyClone.Core.dtos.MembershipDto;
using SpotifyClone.Core.dtos.PaymentDto;
using SpotifyClone.Core.Utilities.Results.Abstract;
using SpotifyClone.Core.Utilities.Results.Concretes;
using SpotifyClone.Entities.abstracts;
using SpotifyClone.Entities.concretes;
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

        public IResult ControlPaymentInformations(PaymentDto paymentDto, DateTime startDateTime)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 11);

            CreatePaymentInformations(paymentDto, startDateTime);

            if(randomNumber > 7)
            {
                //öncesinde ödemelerin düzenlendiği fonksiyon çağırılmalı
                paymentDto.state = "Limit yetersiz";
                Insert(paymentDto);
                return new ErrorResult("Ödeme işlemi gerçekleştirilemedi : Limit yetersiz");
            }
            else if (randomNumber == 1)
            {
                paymentDto.state = "Kart Bilgileri Yanlış";
                Insert(paymentDto);
                return new ErrorResult("Ödeme işlemi gerçekleştirilemedi : Kart Bilgileri Yanlış");
            }
            else
            {
                 paymentDto.state = "Ödendi";
                 Insert(paymentDto);
                return new SuccessResult("Ödeme işlemi onaylandı . Tutar : " );
            }
            throw new NotImplementedException();
        }

        public IResult CreatePaymentInformations(PaymentDto paymentDto, DateTime startDateTime)
        {
            string cardNo = paymentDto.cardNo;
            paymentDto.paymentDate = startDateTime;
            paymentDto.cardNo = cardNo.Substring(0, 4) + new string('*', cardNo.Length - 8) + cardNo.Substring(cardNo.Length - 4);
            paymentDto.cvc = "**" + paymentDto.cvc[2];
            // paymentDto.price = membershipType.price;
            // paymentDto.state = "Ödendi";
            return new SuccessResult();
        }

        public IResult Insert(PaymentDto paymentDto)
        {
            _paymentRepository.Insert(paymentDto);
            return new SuccessResult("Ödeme Bilgileri Eklendi");
        }
    }
}
