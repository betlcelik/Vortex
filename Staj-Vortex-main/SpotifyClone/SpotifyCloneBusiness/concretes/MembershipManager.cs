using System;
using Spotify.core.dtos.MembershipDto;
using Spotify.core.dtos.PlaylistDto;
using Spotify.entities.abstracts;
using Spotify.entities.concretes;
using SpotifyClone.Business.abstracts;
using SpotifyClone.Core.abstracts;
using SpotifyClone.Core.concretes;
using SpotifyClone.Core.Utilities.Results.Abstract;
using SpotifyClone.Core.Utilities.Results.Concretes;

namespace SpotifyClone.Business.concretes
{
	public class MembershipManager : IMembershipService
	{
        private readonly IMembershipRepository _membershipRepository;

		public MembershipManager(IMembershipRepository membershipRepository)
		{
            _membershipRepository = membershipRepository;
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

