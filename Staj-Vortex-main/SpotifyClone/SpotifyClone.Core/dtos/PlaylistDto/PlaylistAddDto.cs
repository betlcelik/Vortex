using System;
using Spotify.entities.abstracts;

namespace Spotify.core.dtos.PlaylistDto
{
	public class PlaylistAddDto
	{
		public PlaylistAddDto()
		{
		}

		
		public int userId { get; set; }
        public string title { get; set; }
    }
}

