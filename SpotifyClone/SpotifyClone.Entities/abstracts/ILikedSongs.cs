using System;
namespace SpotifyClone.Entities.abstracts
{
	public interface ILikedSongs
	{
		int id { get; set; }
		int userId { get; set; }
		int songId { get; set; }
	
    }
}

