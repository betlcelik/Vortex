using System;
using System.ComponentModel.DataAnnotations;

namespace Spotify.entities.abstracts
{
	public interface IGenre
	{
        [Key]
        int id { get; set; }
        
		string title { get; set; }
    }
}

