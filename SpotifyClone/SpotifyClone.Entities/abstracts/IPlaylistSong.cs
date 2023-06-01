using System;
namespace SpotifyClone.Entities.abstracts
{
	public interface IPlaylistSong
	{
		int id { get; set; }
		int playlistId { get; set; }
		int songId { get; set; }
	}
}

