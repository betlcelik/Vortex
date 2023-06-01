using System;
using SpotifyClone.Entities.abstracts;

namespace SpotifyClone.Entities.concretes
{
	public class LikedSongs : ILikedSongs
	{
		public LikedSongs()
		{
		}

        public int id { get; set; }
        public int userId { get; set; }
        public int songId { get; set; }
      
    }
}

