using System;
using SpotifyClone.Entities.abstracts;

namespace SpotifyClone.Entities.concretes
{
	public class SavedSongs : ISavedSongs
	{
		public SavedSongs()
		{
		}

        public int id { get; set; }
        public int userId { get; set; }
        public int songId { get; set; }
       
    }
}

