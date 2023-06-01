using System;
using System.ComponentModel.DataAnnotations;

namespace Spotify.entities.abstracts
{
	public interface ICountry
	{
        [Key]
        int id { get; set; }

		string countryName { get; set; }
    }
}

