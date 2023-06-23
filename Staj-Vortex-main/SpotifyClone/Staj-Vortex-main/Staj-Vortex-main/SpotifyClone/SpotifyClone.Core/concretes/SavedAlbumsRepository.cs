using System;
using Spotify.core.concretes;
using Spotify.core.DbConnection.EntityFramework;
using SpotifyClone.Core.abstracts;
using SpotifyClone.Core.dtos.SavedAlbumsDto;

namespace SpotifyClone.Core.concretes
{
	public class SavedAlbumsRepository : Repository<SavedAlbumsDto>, ISavedAlbumsRepository
	{
		public SavedAlbumsRepository(DataBaseConnection context) : base(context)
        {
		}
	}
}

