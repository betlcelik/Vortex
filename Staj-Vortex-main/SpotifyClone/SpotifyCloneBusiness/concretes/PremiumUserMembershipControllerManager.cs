
using SpotifyClone.Business.abstracts;
using SpotifyClone.Core.Utilities.Results.Abstract;
using SpotifyClone.Core.Utilities.Results.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Business.concretes
{
    public class PremiumUserMembershipControllerManager : IPremiumUserMembershipControlService
    {
        private IMembershipService _membershipService;
        public PremiumUserMembershipControllerManager(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }
        public IResult ChechkIsMembershipUpToEnd(int userId)
        {
            DateTime currentDateTime = DateTime.Now.ToUniversalTime().Date;
            var membership=_membershipService.GetByUserId(userId).Data.FirstOrDefault();
            if(membership.membershipTypeId != 1 && currentDateTime.AddDays(1) == membership.endDate)
            {
                return new SuccessResult("Today is the last day of your membership.You may wish to renew it.");
            }
            return new SuccessResult();
        }

        public IResult CheckIsMembershipFinished(int userId)
        {
            DateTime currentDateTime = DateTime.Now.ToUniversalTime().Date;
            var membership = _membershipService.GetByUserId(userId).Data.FirstOrDefault();
            if(membership.endDate == currentDateTime)
            {
                membership.membershipTypeId = 1;
                membership.startDate = currentDateTime;
                membership.endDate = DateTime.MaxValue;
                _membershipService.Update(membership);
                return new SuccessResult("User membership has been changed to free membership");
            }
            return new SuccessResult();
        }
    }
}
