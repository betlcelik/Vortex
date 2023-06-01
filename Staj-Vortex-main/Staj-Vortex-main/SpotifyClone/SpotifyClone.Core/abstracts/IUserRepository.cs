using System;
using Spotify.core.abstracts;
using Spotify.core.dtos.UserDto;
using Spotify.entities.abstracts;
using SpotifyClone.Core.dtos.UserDto;

namespace SpotifyClone.Core.abstracts
{
	public interface IUserRepository : IRepository<UserDto>
	{
        UserDto Login(UserLoginDto userLoginDto);


    }


}

