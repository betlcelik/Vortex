using System;
using System.ComponentModel.DataAnnotations;
using Spotify.entities.concretes;

namespace Spotify.entities.abstracts
{
	public interface ISong
	{
        [Key]
        int id { get; set; }

		string isrc { get; set; }
		string title { get; set; }
		int genreId { get; set; }
		int artistId { get; set; }
		int albumId { get; set; }
		DateTime releaseDate { get; set; }
		int totalLikes { get; set; }
        string image { get; set; }
        int plays { get; set; }
		string duration { get; set; }
		string availableMarkets { get; set; }

    }
}

