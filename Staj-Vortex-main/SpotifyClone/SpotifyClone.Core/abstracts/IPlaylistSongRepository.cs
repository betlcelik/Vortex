using System;
using Spotify.core.abstracts;
using SpotifyClone.Core.dtos.PlaylistSongDto;

namespace SpotifyClone.Core.abstracts
{
	public interface IPlaylistSongRepository : IRepository<PlaylistSongDto>
	{
	}
}

