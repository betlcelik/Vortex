using System;
using System.ComponentModel.DataAnnotations;
using Spotify.entities.abstracts;

namespace Spotify.entities.concretes
{
	public class User : IUser
	{ 

		public User()
		{
		}

        [Key]
        public int id { get; set; }

        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int? countryId { get; set; }
        public DateTime? creationDate { get; set; }
        public int? totalFollowers { get; set; }
        public int? totalFollowings { get; set; }
        public string? device { get; set; }
        public string? image { get; set; }
    }
}

