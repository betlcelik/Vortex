using System;
using SpotifyClone.Core.dtos.LikedSongsDto;
using SpotifyClone.Core.Utilities.Results.Abstract;

namespace SpotifyClone.Business.abstracts
{
	public interface ILikedSongsService
	{

        IDataResult<IEnumerable<LikedSongsDto>> GetAll();
        IResult Delete(LikedSongsDto likedSongs);
        IResult DeleteById(int id);
        IDataResult<LikedSongsDto> GetById(int id);
        IResult Insert(LikedSongsDto likedSongs);
        IDataResult<IEnumerable<LikedSongsDto>> GetAllByUserId(int userId);
    }
}

