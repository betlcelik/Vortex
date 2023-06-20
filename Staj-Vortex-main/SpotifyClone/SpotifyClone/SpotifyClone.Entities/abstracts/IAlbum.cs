using System;
using System.ComponentModel.DataAnnotations;
using Spotify.entities.concretes;

namespace Spotify.entities.abstracts
{
	public interface IAlbum
	{
		[Key]
		int id { get; set; }

		string title { get; set; }
		int artistId { get; set; }
		int totalTracks { get; set; }
		int genreId { get; set; }
		int totalLikes { get; set; }
		DateTime releaseDate { get; set; }
        string image { get; set; }
        
    }
}

