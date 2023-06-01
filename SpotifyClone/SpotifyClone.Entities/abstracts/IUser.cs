using System;
using System.ComponentModel.DataAnnotations;
using Spotify.entities.concretes;

namespace Spotify.entities.abstracts
{
	public interface IUser
	{
        
        int id { get; set; }
		string userName { get; set; }
		string password { get; set; }
		string email { get; set; }
		int? countryId { get; set; }
        string? image { get; set; }
        DateTime? creationDate { get; set; }
		int? totalFollowers { get; set; }
        int? totalFollowings { get; set; }
		string? device { get; set; }
    }
}

