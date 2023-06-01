using System;
namespace SpotifyClone.Entities.abstracts
{
	public interface ISavedSongs
	{
		int id { get; set; }
		int userId { get; set; }
		int songId { get; set; }
	
    }
}

