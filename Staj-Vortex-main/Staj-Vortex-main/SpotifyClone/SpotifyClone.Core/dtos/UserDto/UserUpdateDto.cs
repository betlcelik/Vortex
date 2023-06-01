using System;
namespace SpotifyClone.Core.dtos.UserDto
{
	public class UserUpdateDto
	{
        public int id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string image { get; set; }
        public int countryId { get; set; }

    }
}

