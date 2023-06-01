using System;
using Spotify.entities.abstracts;

namespace Spotify.core.dtos.AlbumDto
{
	public class AlbumAddDto
	{
		public AlbumAddDto()
		{
		}

        public string title { get; set; }
        public int artistId { get; set; }
        
        public int totalTracks { get; set; }
        public int genreId { get; set; }
        public DateTime releaseDate { get; set; }
        public string image { get; set; }
        
    }
}

