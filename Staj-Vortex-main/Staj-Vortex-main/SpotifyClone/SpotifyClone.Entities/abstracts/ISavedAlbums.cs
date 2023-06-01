using System;
namespace SpotifyClone.Entities.abstracts
{
	public interface ISavedAlbums
	{
		int id { get; set; }
		int userId { get; set; }
		int albumId { get; set; }
	
    }
}

