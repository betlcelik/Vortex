using System;
using Spotify.core.concretes;
using Spotify.core.DbConnection.EntityFramework;
using Spotify.core.dtos.SongDto;
using SpotifyClone.Core.abstracts;

namespace SpotifyClone.Core.concretes
{
	public class SongRepository : Repository<SongDto>, ISongRepository
	{
		public SongRepository(DataBaseConnection context) : base(context)
        {
        }
    }
}

