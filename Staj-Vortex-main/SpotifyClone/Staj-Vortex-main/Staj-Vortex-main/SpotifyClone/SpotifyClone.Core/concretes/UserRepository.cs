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

       
    }
}




