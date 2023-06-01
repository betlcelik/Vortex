using System;
using System.ComponentModel.DataAnnotations;
using Spotify.entities.abstracts;

namespace Spotify.entities.concretes
{
	[Serializable]
	public class Country : ICountry
	{
		public Country()
		{
		}

        [Key]
        public int id { get; set; }

        public string countryName { get; set; }
    }
}

