using System;
using SpotifyClone.Entities.abstracts;

namespace SpotifyClone.Entities.concretes
{
	public class SavedAlbums : ISavedAlbums
	{
		public SavedAlbums()
		{
		}

        public int id { get; set; }
        public int userId { get; set; }
        public int albumId { get; set; }
    }
}

