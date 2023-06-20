using Spotify.core.abstracts;
using SpotifyClone.Core.dtos;
using SpotifyClone.Core.dtos.UserStatisticDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Core.abstracts
{
    public interface IUserStatisticRepository : IRepository<UserStatisticDto>
    {
    }
}
