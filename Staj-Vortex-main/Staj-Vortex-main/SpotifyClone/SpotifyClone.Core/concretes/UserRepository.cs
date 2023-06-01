using System;
using Microsoft.EntityFrameworkCore;
using Spotify.core.concretes;
using Spotify.core.DbConnection.EntityFramework;
using Spotify.core.dtos.UserDto;
using Spotify.entities.abstracts;
using SpotifyClone.Core.abstracts;
using SpotifyClone.Core.dtos.UserDto;

namespace SpotifyClone.Core.concretes
{
    public class UserRepository : Repository<UserDto>, IUserRepository

    {

        private readonly DataBaseConnection _context;
        public UserRepository(DataBaseConnection context) : base(context)
        {
            _context = context;
        }

        UserDto IUserRepository.Login(UserLoginDto userLoginDto)
        {
            //string credential;

            if (!string.IsNullOrEmpty(userLoginDto.loginCredential))
            {
                if (_context.Set<UserDto>()
                .SingleOrDefault(u => u.userName == userLoginDto.loginCredential && u.password == userLoginDto.password) != null)
                {
                    // credential = "userName";
                    return _context.Set<UserDto>()
                 .SingleOrDefault(u => u.userName == userLoginDto.loginCredential && u.password == userLoginDto.password);
                }

                else if (_context.Set<UserDto>()
                .SingleOrDefault(u => u.email == userLoginDto.loginCredential && u.password == userLoginDto.password) != null)
                {
                    // credential = "email";
                    return _context.Set<UserDto>()
                   .SingleOrDefault(u => u.email == userLoginDto.loginCredential && u.password == userLoginDto.password);
                }
                else
                {
                    return null;
                }


            }
            return null;
        }
    }
}




