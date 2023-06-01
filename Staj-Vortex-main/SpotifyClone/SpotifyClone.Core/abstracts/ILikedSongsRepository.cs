using System;
using Spotify.core.abstracts;
using SpotifyClone.Core.dtos.LikedSongsDto;

namespace SpotifyClone.Core.abstracts
{
	public interface ILikedSongsRepository : IRepository<LikedSongsDto>
	{
	}
}

