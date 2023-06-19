using System;
using Spotify.core.dtos.MembershipDto;
using SpotifyClone.Core.dtos.MembershipDto;
using SpotifyClone.Core.Utilities.Results.Abstract;

namespace SpotifyClone.Business.abstracts
{
	public interface IMembershipService
	{
        IDataResult<IEnumerable<MembershipDto>> GetAll();
        IResult Delete(MembershipDto membership);
        IResult DeleteById(int id);
        IDataResult<MembershipDto> GetById(int id);
        IDataResult<IEnumerable<MembershipDto>> GetByUserId(int userId);
        IResult Insert(MembershipDto membership);
        IResult Update(MembershipDto membership);
        IResult BuyMembership(MembershipPaymentDto membershipPaymentDto);
    }
}

