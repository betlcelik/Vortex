using System;
using System.Data;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Spotify.core.dtos.MembershipDto;
using SpotifyClone.Business.abstracts;
using SpotifyClone.Core.abstracts;
using SpotifyClone.Core.concretes;
using SpotifyClone.Core.dtos.MembershipDto;
using SpotifyClone.Core.dtos.PaymentDto;
using SpotifyClone.Core.Utilities.Results.Abstract;
using SpotifyClone.Core.Utilities.Results.Concretes;
using SpotifyClone.Entities.abstracts;
using SpotifyClone.Entities.concretes;

namespace SpotifyClone.Business.concretes
{
	public class MembershipManager : IMembershipService
	{
        private readonly IMembershipRepository _membershipRepository;
        private readonly IMembershipTypeService _membershipTypeService;
        private readonly IPaymentService _paymentService;
        
		public MembershipManager(IMembershipRepository membershipRepository, IMembershipTypeService membershipTypeService,IPaymentService paymentService)
		{
            _membershipRepository = membershipRepository;
            _membershipTypeService = membershipTypeService; 
            _paymentService = paymentService;
            
        }

       

        public IResult Delete(MembershipDto membership)
        {
            _membershipRepository.Delete(membership);
            return new SuccessResult("Üyelik silindi.");
        }

        public IResult DeleteById(int id)
        {
            _membershipRepository.DeleteById(id);
            return new SuccessResult("Üyelik silindi.");
        }

        public IResult DowngradeMembership(int userId)
        {
            var member = GetByUserId(userId).Data.FirstOrDefault();
            member.membershipTypeId = 1;
            member.startDate = member.endDate;
            member.endDate = DateTime.MaxValue;
            Update(member);
            return new SuccessResult("Üyelik iptal edildi");
        }

        public IDataResult<IEnumerable<MembershipDto>> GetAll()
        {
            return new SuccessDataResult<IEnumerable<MembershipDto>>(_membershipRepository.GetAll(), "Üyelikler listelendi.");
        }

        public IDataResult<IEnumerable<MembershipDto>> GetAllFreeMemberships()
        {
            return new SuccessDataResult<IEnumerable<MembershipDto>>(_membershipRepository.GetAll(membership => membership.membershipTypeId == 1), "Free Üyelikler Listeleniyor");
        }

        public IDataResult<IEnumerable<MembershipDto>> GetAllPremimumMemberships()
        {
            return new SuccessDataResult<IEnumerable<MembershipDto>>(_membershipRepository.GetAll(membership => membership.membershipTypeId != 1),"Premium Üyelikler Listeleniyor");
        }

        public IDataResult<IEnumerable<MembershipDto>> GetAllStudentMemberships()
        {
            return new SuccessDataResult<IEnumerable<MembershipDto>>(_membershipRepository.GetAll(membership => membership.membershipTypeId == 3), "Öğrenci Üyelikleri Listeleniyor");
        }

        public IDataResult<MembershipDto> GetById(int id)
        {
            return new SuccessDataResult<MembershipDto>(_membershipRepository.GetById(id));
        }

        public IDataResult<IEnumerable<MembershipDto>> GetByMembershipTypeId(int membershipTypeId)
        {
           return new SuccessDataResult<IEnumerable<MembershipDto>>(_membershipRepository.GetAll(membership => membership.membershipTypeId == membershipTypeId),"Üyelikler listeleniyor");
            throw new NotImplementedException();
        }

        public IDataResult<IEnumerable<MembershipDto>> GetByUserId(int userId)
        {

           return new SuccessDataResult<IEnumerable<MembershipDto>>(_membershipRepository.GetAll(membership => membership.userId == userId));
        }

        public IResult Insert(MembershipDto membership)
        {
           
            _membershipRepository.Insert(membership);
            return new SuccessResult("Üyelik eklendi.");
        }

        public IResult RenewMembership(PaymentDto membershipPaymentDto)
        {
            var membership = GetByUserId(membershipPaymentDto.userId).Data.FirstOrDefault();
            DateTime startDateTime = membership.endDate;
            
            var membershipType = _membershipTypeService.GetById(membership.membershipTypeId).Data;
            membershipPaymentDto.membershipTypeId = membership.membershipTypeId;
            membershipPaymentDto.price = membershipType.price;
            _paymentService.ControlPaymentInformations(membershipPaymentDto,startDateTime);

            membership.startDate= startDateTime;
            membership.endDate= startDateTime.AddMonths(1).ToUniversalTime();
            Update(membership);
            return new SuccessResult("Üyelik yenileme işlemi " + membershipType.price +" karşılığında yenilendi.");
        }

        public IResult Update(MembershipDto membership)
        {
            _membershipRepository.Update(membership);
            return new SuccessResult("Üyelik bilgileri güncellendi.");
        }

        public IResult UpgradeMembership(PaymentDto membershipPaymentDto)
        {

            DateTime startDateTime = DateTime.Now.ToUniversalTime().Date;
            var member = GetByUserId(membershipPaymentDto.userId).Data.FirstOrDefault();
            var membershipType = _membershipTypeService.GetById(membershipPaymentDto.membershipTypeId).Data;
            member.startDate = startDateTime;
            member.endDate = startDateTime.AddMonths(1).ToUniversalTime();
            member.membershipTypeId = membershipPaymentDto.membershipTypeId;

            membershipPaymentDto.price = membershipType.price;

            _paymentService.ControlPaymentInformations(membershipPaymentDto, startDateTime);
            Update(member);
            return new SuccessResult("Ödeme işlemi onaylandı . Tutar : " + membershipType.price);

           
        }


    }
}

