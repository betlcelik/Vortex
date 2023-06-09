﻿using System;
using Spotify.core.abstracts;
using Spotify.core.dtos.AlbumDto;

namespace SpotifyClone.Core.abstracts
{
	public interface IAlbumRepository : IRepository<AlbumDto>
	{
		public int GetTotalTracksByAlbumId(int albumId);
		//new IEnumerable<AlbumDto> GetAll();
	}
}

