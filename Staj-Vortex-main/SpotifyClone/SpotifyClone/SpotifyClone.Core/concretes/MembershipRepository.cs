using System;
using Spotify.core.concretes;
using Spotify.core.DbConnection.EntityFramework;
using Spotify.core.dtos.MembershipDto;
using SpotifyClone.Core.abstracts;

namespace SpotifyClone.Core.concretes
{
	public class MembershipRepository : Repository<MembershipDto>, IMembershipRepository
	{
		public MembershipRepository(DataBaseConnection context) : base(context)
        {
        }
    }
}

