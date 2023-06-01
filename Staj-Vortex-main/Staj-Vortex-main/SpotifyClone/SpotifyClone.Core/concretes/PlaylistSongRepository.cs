using System;
using Spotify.core.concretes;
using Spotify.core.DbConnection.EntityFramework;
using SpotifyClone.Core.abstracts;
using SpotifyClone.Core.dtos.PlaylistSongDto;

namespace SpotifyClone.Core.concretes
{
	public class PlaylistSongRepository : Repository<PlaylistSongDto>, IPlaylistSongRepository
	{
		public PlaylistSongRepository(DataBaseConnection context) : base(context)
        {
		}
	}
}

