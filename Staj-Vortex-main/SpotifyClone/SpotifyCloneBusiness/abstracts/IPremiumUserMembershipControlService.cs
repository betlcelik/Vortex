
using SpotifyClone.Core.Utilities.Results.Abstract;
using SpotifyClone.Core.Utilities.Results.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Business.abstracts
{
    public interface IPremiumUserMembershipControlService
    {
        public IResult ChechkIsMembershipUpToEnd(int userId);
        public IResult CheckIsMembershipFinished(int userId);
    }
}
