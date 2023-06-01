using System;
using Spotify.core.concretes;
using Spotify.core.DbConnection.EntityFramework;
using Spotify.core.dtos.ArtistDto;
using SpotifyClone.Core.abstracts;

namespace SpotifyClone.Core.concretes
{
	public class ArtistRepository : Repository<ArtistDto>, IArtistRepository
    {
        public ArtistRepository(DataBaseConnection context) : base(context)
        {
        }
    }
}

