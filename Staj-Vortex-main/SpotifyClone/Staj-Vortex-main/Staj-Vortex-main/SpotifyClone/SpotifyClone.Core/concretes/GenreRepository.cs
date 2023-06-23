using System;
using Spotify.core.concretes;
using Spotify.core.DbConnection.EntityFramework;
using Spotify.core.dtos.GenreDto;
using SpotifyClone.Core.abstracts;

namespace SpotifyClone.Core.concretes
{
	public class GenreRepository : Repository<GenreDto>, IGenreRepository
	{
		public GenreRepository(DataBaseConnection context) : base(context)
        {
        }
    }
}

