using System;
using Spotify.core.concretes;
using Spotify.core.DbConnection.EntityFramework;
using SpotifyClone.Core.abstracts;
using SpotifyClone.Core.dtos.SavedSongsDto;

namespace SpotifyClone.Core.concretes
{
	public class SavedSongsRepository : Repository<SavedSongsDto>, ISavedSongsRepository
	{
		public SavedSongsRepository(DataBaseConnection context) : base(context)
        {
		}
	}
}

