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
        public string image { get; set; }
        
    }
}

