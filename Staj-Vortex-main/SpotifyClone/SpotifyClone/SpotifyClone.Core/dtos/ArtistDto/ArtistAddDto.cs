using System;
using Spotify.entities.abstracts;

namespace Spotify.core.dtos.ArtistDto
{
	public class ArtistAddDto
	{
		public ArtistAddDto()
		{
		}

        public string fullName { get; set; }
        public string about { get; set; }
        public string image { get; set; }
    }
}

