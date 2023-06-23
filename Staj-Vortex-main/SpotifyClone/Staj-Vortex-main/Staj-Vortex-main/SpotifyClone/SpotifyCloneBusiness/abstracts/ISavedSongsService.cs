using System;
using SpotifyClone.Core.dtos.PlaylistSongDto;
using SpotifyClone.Core.dtos.SavedSongsDto;
using SpotifyClone.Core.Utilities.Results.Abstract;

namespace SpotifyClone.Business.abstracts
{
	public interface ISavedSongsService
	{

        IDataResult<IEnumerable<SavedSongsDto>> GetAll();
        IResult Delete(SavedSongsDto savedSong);
        IResult DeleteById(int id);
        IDataResult<SavedSongsDto> GetById(int id);
        IResult Insert(SavedSongsDto savedSong);
        IDataResult<IEnumerable<SavedSongsDto>> GetAllByUserId(int userId);
    }
}

