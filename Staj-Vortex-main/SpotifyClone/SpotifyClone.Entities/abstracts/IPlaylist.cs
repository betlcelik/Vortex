using System;
using System.ComponentModel.DataAnnotations;
using Spotify.entities.concretes;

namespace Spotify.entities.abstracts
{
	public interface IPlaylist
	{
        [Key]
        int id { get; set; }
        string title { get; set; }
		int userId { get; set; }
        DateTime creationDate { get; set; }

    }
}

