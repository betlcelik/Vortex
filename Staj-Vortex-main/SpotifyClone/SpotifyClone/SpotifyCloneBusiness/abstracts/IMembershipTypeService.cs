
using SpotifyClone.Core.dtos.MembershipTypeDto;
using SpotifyClone.Core.Utilities.Results.Abstract;



namespace SpotifyClone.Business.abstracts
{
    public interface IMembershipTypeService
    {
        IDataResult<MembershipTypeDto> GetById(int id);
        IResult Insert(MembershipTypeDto membershipType);
        IDataResult<IEnumerable<MembershipTypeDto>> GetAll();
       
    }
}
