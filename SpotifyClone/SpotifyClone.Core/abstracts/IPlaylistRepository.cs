using System;
using Spotify.core.abstracts;
using Spotify.core.dtos.PlaylistDto;

namespace SpotifyClone.Core.abstracts
{
	public interface IPlaylistRepository : IRepository<PlaylistDto>
	{
	}
}

