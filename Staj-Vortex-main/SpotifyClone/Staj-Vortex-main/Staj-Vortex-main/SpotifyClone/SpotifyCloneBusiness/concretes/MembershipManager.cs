using System;
using System.Data;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Spotify.core.dtos.MembershipDto;
using Spotify.core.dtos.PlaylistDto;
using Spotify.entities.abstracts;
using Spotify.entities.concretes;
using SpotifyClone.Business.abstracts;
using SpotifyClone.Core.abstracts;
using SpotifyClone.Core.concretes;
using SpotifyClone.Core.dtos.MembershipDto;
using SpotifyClone.Core.dtos.PaymentDto;
using SpotifyClone.Core.Utilities.Results.Abstract;
using SpotifyClone.Core.Utilities.Results.Concretes;
using SpotifyClone.Entities.concretes;

namespace SpotifyClone.Business.concretes
{
	public class MembershipManager : IMembershipService
	{
        private readonly IMembershipRepository _membershipRepository;
        private readonly IMembershipTypeRepository _membershipTypeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPaymentService _paymentService;
        
		public MembershipManager(IMembershipRepository membershipRepository, IMembershipTypeRepository membershipTypeRepository,IPaymentService paymentService)
		{
            _membershipRepository = membershipRepository;
            _membershipTypeRepository = membershipTypeRepository;
            _paymentService = paymentService;
            
        }

        public IResult BuyMembership(PaymentDto membershipPaymentDto)
        {
            DateTime startDateTime = DateTime.Now.ToUniversalTime().Date;
            DateTime endDateTime = startDateTime.AddMonths(1).ToUniversalTime();
            var member = GetByUserId(membershipPaymentDto.userId).Data.FirstOrDefault();
            MembershipType membershipType = _membershipTypeRepository.GetById(membershipPaymentDto.membershipTypeId);
            if ( member == null)
            {
                   //ücretsiz üyelik oluşturuluyor değiştirme yapılmalı 
                MembershipDto membership = new MembershipDto();
                membership.userId = membershipPaymentDto.userId;
                membership.membershipTypeId = membershipPaymentDto.membershipTypeId;
                membership.startDate = startDateTime;
                membership.endDate = endDateTime;
                Insert(membership);
                return new SuccessResult("Ödeme işlemi onaylandı . Tutar : " + membershipType.price);

            }
            member.startDate = startDateTime;
            member.endDate = endDateTime;
            member.membershipTypeId = membershipPaymentDto.membershipTypeId;
            Update(member);
            
            
            
            
            return new SuccessResult("Ödeme işlemi onaylandı . Tutar : " + membershipType.price);
        }

        public IResult Delete(MembershipDto membership)
        {
            _membershipRepository.Delete(membership);
            return new SuccessResult("Kullanıcı silindi.");
        }

        public IResult DeleteById(int id)
        {
            _membershipRepository.DeleteById(id);
            return new SuccessResult("Kullanıcı silindi.");
        }

        public IResult DowngradeMembership(int userId)
        {
            DateTime startDateTime = DateTime.Now.ToUniversalTime().Date;
            var member = GetByUserId(userId).Data.FirstOrDefault();
            member.membershipTypeId = 1;
            member.startDate = startDateTime;
            member.endDate = DateTime.MaxValue;
            Update(member);
            return new SuccessResult("Üyelik iptal edildi");
        }

        public IDataResult<IEnumerable<MembershipDto>> GetAll()
        {
            return new SuccessDataResult<IEnumerable<MembershipDto>>(_membershipRepository.GetAll(), "Kullanıcılar listelendi.");
        }

        public IDataResult<MembershipDto> GetById(int id)
        {
            return new SuccessDataResult<MembershipDto>(_membershipRepository.GetById(id));
        }

        public IDataResult<IEnumerable<MembershipDto>> GetByUserId(int userId)
        {

           return new SuccessDataResult<IEnumerable<MembershipDto>>(_membershipRepository.GetAll(membership => membership.userId == userId));
        }

        public IResult Insert(MembershipDto membership)
        {
           
            _membershipRepository.Insert(membership);
            return new SuccessResult("Kullanıcı eklendi.");
        }

        public IResult Update(MembershipDto membership)
        {
            _membershipRepository.Update(membership);
            return new SuccessResult("Kullanıcı bilgileri güncellendi.");
        }

        public IResult UpgradeMembership(PaymentDto membershipPaymentDto)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 11);
            DateTime startDateTime = DateTime.Now.ToUniversalTime().Date;
            DateTime endDateTime = startDateTime.AddMonths(1).ToUniversalTime();
            string cardNo;
            var member = GetByUserId(membershipPaymentDto.userId).Data.FirstOrDefault();
            MembershipType membershipType = _membershipTypeRepository.GetById(membershipPaymentDto.membershipTypeId);
            member.startDate = startDateTime;
            member.endDate = endDateTime;
            member.membershipTypeId = membershipPaymentDto.membershipTypeId;
            membershipPaymentDto.paymentDate = startDateTime;
            cardNo= membershipPaymentDto.cardNo;
            membershipPaymentDto.cardNo = cardNo.Substring(0,4)+ new string('*',cardNo.Length -8 )+ cardNo.Substring(cardNo.Length-4);
            membershipPaymentDto.cvc = "**" + membershipPaymentDto.cvc[2];
            membershipPaymentDto.price = membershipType.price;

            if(randomNumber > 8)
            {
                membershipPaymentDto.state = "Limit yetersiz";
                _paymentService.Insert(membershipPaymentDto);
                return new ErrorResult("Ödeme işlemi gerçekleştirilemedi : Limit yetersiz");

            }
            if(randomNumber == 1) 
            {
                 membershipPaymentDto.state = "Kart Bilgileri Yanlış";
                _paymentService.Insert(membershipPaymentDto);
                return new ErrorResult("Ödeme işlemi gerçekleştirilemedi : Kart Bilgileri Yanlış");
            }
            membershipPaymentDto.state = "Ödendi";
            _paymentService.Insert(membershipPaymentDto);
            Update(member);
            return new SuccessResult(randomNumber + "Ödeme işlemi onaylandı . Tutar : " + membershipType.price);

           
        }


    }
}

