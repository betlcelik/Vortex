using Spotify.core.abstracts;
using Spotify.core.concretes;
using Spotify.core.DbConnection.EntityFramework;
using SpotifyClone.Core.abstracts;
using SpotifyClone.Core.dtos.MembershipTypeDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Core.concretes
{
    public class MembershipTypeRepository : Repository<MembershipTypeDto>, IMembershipTypeRepository
    {
        public MembershipTypeRepository(DataBaseConnection context) : base(context)
        {
        }
    }
}
