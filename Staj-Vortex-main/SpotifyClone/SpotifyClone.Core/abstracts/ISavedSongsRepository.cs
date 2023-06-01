using System;
using Spotify.core.abstracts;
using SpotifyClone.Core.dtos.SavedSongsDto;

namespace SpotifyClone.Core.abstracts
{
	public interface ISavedSongsRepository : IRepository<SavedSongsDto>
	{
	}
}

