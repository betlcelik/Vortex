using System;
using SpotifyClone.Core.dtos.LikedSongsDto;
using SpotifyClone.Core.Utilities.Results.Abstract;

namespace SpotifyClone.Business.abstracts
{
	public interface ILikedSongsService
	{

        IDataResult<IEnumerable<LikedSongsDto>> GetAll();
        IResult Delete(LikedSongsWithoutIdDto likedSongs);
        IResult DeleteById(int id);
        IDataResult<LikedSongsDto> GetById(int id);
        IResult Insert(LikedSongsDto likedSongs);
        IDataResult<IEnumerable<LikedSongsDto>> GetAllByUserId(int userId);
        IDataResult<IEnumerable<LikedSongsDto>> GetAllBySongId(int songId);
        IDataResult<IEnumerable<LikedSongsDto>> GetAllByUserIdAndGenreId(int userId, int genreId);
        int GetMostLikedSongGenreIdByUserId(int userId);
    }
}

