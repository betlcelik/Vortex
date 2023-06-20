using System;
using SpotifyClone.Entities.abstracts;

namespace SpotifyClone.Entities.concretes
{
	public class PlaylistSong : IPlaylistSong
	{
		public PlaylistSong()
		{
		}

		public int id { get; set; }
        public int playlistId { get; set; }
        public int songId { get; set; }
    }
}

