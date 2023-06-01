using System;
using System.ComponentModel.DataAnnotations;
using Spotify.entities.concretes;

namespace Spotify.entities.abstracts
{
	public interface IArtist
	{
        [Key]
        int id { get; set; }

		string fullName { get; set; }
		string about { get; set; }
        string image { get; set; }
    }
}

