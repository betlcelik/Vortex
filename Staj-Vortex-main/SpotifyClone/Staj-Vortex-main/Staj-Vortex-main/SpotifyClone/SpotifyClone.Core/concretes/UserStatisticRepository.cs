using Spotify.core.abstracts;
using Spotify.core.concretes;
using Spotify.core.DbConnection.EntityFramework;
using SpotifyClone.Core.abstracts;
using SpotifyClone.Core.dtos;
using SpotifyClone.Core.dtos.UserStatisticDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Core.concretes
{
    public class UserStatisticRepository : Repository<UserStatisticDto>, IUserStatisticRepository
    {
        private readonly DataBaseConnection _context;
        public UserStatisticRepository(DataBaseConnection context) : base(context)
        {
            _context = context;
        }
    }
}
