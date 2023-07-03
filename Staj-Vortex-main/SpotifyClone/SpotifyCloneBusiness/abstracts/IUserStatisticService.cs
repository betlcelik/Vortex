using SpotifyClone.Core.dtos;
using SpotifyClone.Core.dtos.UserStatisticDto;
using SpotifyClone.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Business.abstracts
{
    public interface IUserStatisticService
    {
        IDataResult<IEnumerable<UserStatisticDto>> GetUserStatisticByUserId(int userId);
        IDataResult<IEnumerable<UserStatisticDto>> ShowUserStatisticByUserId(int userId);
        IResult AddUserStatistics(UserStatisticDto addUserStatisticDto);
        IResult Update(UserStatisticDto updateUserStatisticDto);
        IResult DeleteById(int id);
        IResult IncreaseLikedSongs(int userId);
        IResult DecraseLikedSongs(int userId);
        IResult IncreasePlayLists(int userId);
        IResult DecrasePlayLists(int userId);

        
    }
}
