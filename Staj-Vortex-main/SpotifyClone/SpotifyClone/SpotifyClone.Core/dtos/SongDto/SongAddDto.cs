using System;
using Spotify.entities.abstracts;

namespace Spotify.core.dtos.SongDto
{
	public class SongAddDto
	{
		public SongAddDto()
		{
		}

		public string isrc { get; set; }
        public string title { get; set; }
        public int genreId { get; set; }
        public int artistId { get; set; }
        public int albumId { get; set; }
        public DateTime releaseDate { get; set; }
        public string image { get; set; }
        public string duration { get; set; }
        public string availableMarkets { get; set; }
    }
}

