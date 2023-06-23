using System;
using System.ComponentModel.DataAnnotations;
using Spotify.entities.abstracts;

namespace Spotify.entities.concretes
{
	public class Album : IAlbum
	{
		

        [Key]
        public int id { get; set; }

        public string title { get; set; }
        public int artistId { get; set; }
        public int totalTracks { get; set; }
        public DateTime releaseDate { get; set; }
        public string image { get; set; }
        
    }
}

