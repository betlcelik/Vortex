using System;
using Spotify.core.concretes;
using Spotify.core.DbConnection.EntityFramework;
using SpotifyClone.Core.abstracts;
using SpotifyClone.Core.dtos.LikedSongsDto;

namespace SpotifyClone.Core.concretes
{
	public class LikedSongsRepository : Repository<LikedSongsDto>, ILikedSongsRepository
	{
		public LikedSongsRepository(DataBaseConnection context) : base(context)
        {
		}
	}
}

