using System;
using Spotify.core.abstracts;
using Spotify.core.dtos.SongDto;

namespace SpotifyClone.Core.abstracts
{
	public interface ISongRepository : IRepository<SongDto>
	{
	}
}

