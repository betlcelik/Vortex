using System;
using System.Data;
using Microsoft.IdentityModel.Tokens;
using Spotify.core.dtos.MembershipDto;
using Spotify.core.dtos.PlaylistDto;
using Spotify.entities.abstracts;
using Spotify.entities.concretes;
using SpotifyClone.Business.abstracts;
using SpotifyClone.Core.abstracts;
using SpotifyClone.Core.concretes;
using SpotifyClone.Core.dtos.MembershipDto;
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
		public MembershipManager(IMembershipRepository membershipRepository, IMembershipTypeRepository membershipTypeRepository)
		{
            _membershipRepository = membershipRepository;
            _membershipTypeRepository = membershipTypeRepository;
        }

        public IResult BuyMembership(MembershipPaymentDto membershipPaymentDto)
        {
            DateTime startDateTime = DateTime.Now.ToUniversalTime().Date;
            DateTime endDateTime = startDateTime.AddMonths(1).ToUniversalTime();
            MembershipType membershipType = _membershipTypeRepository.GetById(membershipPaymentDto.membershipTypeId);
            MembershipDto membership= new MembershipDto(); 
            membership.userId = membershipPaymentDto.userId;
            membership.membershipTypeId=membershipPaymentDto.membershipTypeId;
            membership.startDate = startDateTime;
            membership.endDate = endDateTime;
            
            Insert(membership);
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
    }
}

