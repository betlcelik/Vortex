using System;
using System.ComponentModel.DataAnnotations;
using Spotify.entities.abstracts;

namespace Spotify.entities.concretes
{
	public class Song : ISong
	{
		public Song()
		{
		}

        [Key]
        public int id { get; set; }
        public string isrc { get; set; }
        public string title { get; set; }
        public int genreId { get; set; }
        public int artistId { get; set; }
        public int albumId { get; set; }
        public DateTime releaseDate { get; set; }
        public int totalLikes { get; set; }
        public string image { get; set; }
        public int plays { get; set; }
        public string duration { get; set; }
        public string? availableMarkets { get; set; }
    }
}

