using SpotifyClone.Business.abstracts;
using SpotifyClone.Core.abstracts;
using SpotifyClone.Core.dtos.MembershipTypeDto;
using SpotifyClone.Core.Utilities.Results.Abstract;
using SpotifyClone.Core.Utilities.Results.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Business.concretes
{
    public class MembershipTypeManager : IMembershipTypeService
    {
        private readonly IMembershipTypeRepository _membershipTypeRepository;
        public MembershipTypeManager(IMembershipTypeRepository membershipTypeRepository)
        {
            _membershipTypeRepository = membershipTypeRepository;
        }

        public IDataResult<IEnumerable<MembershipTypeDto>> GetAll()
        {
           return new SuccessDataResult<IEnumerable<MembershipTypeDto>>(_membershipTypeRepository.GetAll(),"Üyelik tipleri listeleniyor");
        }

        public IDataResult<MembershipTypeDto> GetById(int id)
        {
            return new SuccessDataResult<MembershipTypeDto>(_membershipTypeRepository.GetById(id));
        }

        public IResult Insert(MembershipTypeDto membershipType)
        {
            _membershipTypeRepository.Insert(membershipType);
            return new SuccessResult("Üyelik tipi başarıyla eklendi");
        }
    }
}
