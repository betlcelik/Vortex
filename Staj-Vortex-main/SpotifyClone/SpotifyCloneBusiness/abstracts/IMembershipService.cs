using System;
using Spotify.core.dtos.MembershipDto;
using SpotifyClone.Core.dtos.MembershipDto;
using SpotifyClone.Core.dtos.PaymentDto;
using SpotifyClone.Core.Utilities.Results.Abstract;

namespace SpotifyClone.Business.abstracts
{
	public interface IMembershipService
	{
        IDataResult<IEnumerable<MembershipDto>> GetAll();
        IDataResult<IEnumerable<MembershipDto>> GetAllFreeMemberships();
        IDataResult<IEnumerable<MembershipDto>> GetAllPremimumMemberships();
        IDataResult<IEnumerable<MembershipDto>> GetAllStudentMemberships();
        IResult Delete(MembershipDto membership);
        IResult DeleteById(int id);
        IDataResult<MembershipDto> GetById(int id);
        IDataResult<IEnumerable<MembershipDto>> GetByUserId(int userId);
        IResult Insert(MembershipDto membership);
        IResult Update(MembershipDto membership);
        IResult BuyMembership(PaymentDto membershipPaymentDto);
        IResult UpgradeMembership(PaymentDto membershipPaymentDto);
        IResult DowngradeMembership(int userId);
       
    }
}

