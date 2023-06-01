using System;
using System.ComponentModel.DataAnnotations;
using Spotify.entities.abstracts;

namespace Spotify.entities.concretes
{
	public class Playlist : IPlaylist
	{
		public Playlist()
		{
		}

        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public int userId { get; set; }
        public DateTime creationDate { get; set; }
        
    }
}

