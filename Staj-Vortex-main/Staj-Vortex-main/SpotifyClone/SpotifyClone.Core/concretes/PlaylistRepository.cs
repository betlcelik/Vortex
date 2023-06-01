using System;
using Spotify.core.concretes;
using Spotify.core.DbConnection.EntityFramework;
using Spotify.core.dtos.PlaylistDto;
using SpotifyClone.Core.abstracts;

namespace SpotifyClone.Core.concretes 
{
	public class PlaylistRepository : Repository<PlaylistDto>, IPlaylistRepository
	{
		public PlaylistRepository(DataBaseConnection context) : base(context)
        {
        }
    }
}

