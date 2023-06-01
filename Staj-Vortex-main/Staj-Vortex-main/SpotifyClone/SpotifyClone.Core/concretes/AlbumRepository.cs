using System;
using Spotify.core.concretes;
using Spotify.core.DbConnection.EntityFramework;
using Spotify.core.dtos.AlbumDto;
using SpotifyClone.Core.abstracts;

namespace SpotifyClone.Core.concretes
{
	public class AlbumRepository : Repository<AlbumDto>, IAlbumRepository
	{
		public AlbumRepository(DataBaseConnection context) : base(context)
        {
        }
    }
}

