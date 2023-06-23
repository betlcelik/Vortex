using System;
using System.ComponentModel.DataAnnotations;
using Spotify.entities.abstracts;

namespace Spotify.entities.concretes
{
	public class Genre : IGenre
	{
		public Genre()
		{
		}

        [Key]
        public int id { get; set; }

        public string title { get; set; }
    }
}

