using System;
namespace Spotify.core.dtos.UserDto
{
	public class UserAddDto
	{
		public UserAddDto()
		{
		}

		public string userName { get; set; }
		public string password { get; set; }
        public string email { get; set; }
        public string image { get; set; }
		public int countryId { get; set; }
    }
}

