using System;
using System.ComponentModel.DataAnnotations;
using Spotify.entities.abstracts;

namespace Spotify.entities.concretes
{
	public class Artist : IArtist
	{
		public Artist()
		{
		}

        [Key]
        public int id { get; set; }

        public string fullName { get; set; }
        public string about { get; set; }
        public string image { get; set; }
    }
}

