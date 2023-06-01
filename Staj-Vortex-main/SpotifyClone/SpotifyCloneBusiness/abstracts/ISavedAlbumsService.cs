using System;
using SpotifyClone.Core.dtos.SavedAlbumsDto;
using SpotifyClone.Core.dtos.SavedSongsDto;
using SpotifyClone.Core.Utilities.Results.Abstract;

namespace SpotifyClone.Business.abstracts
{
	public interface ISavedAlbumsService
	{

        IDataResult<IEnumerable<SavedAlbumsDto>> GetAll();
        IResult Delete(SavedAlbumsDto savedAlbum);
        IResult DeleteById(int id);
        IDataResult<SavedAlbumsDto> GetById(int id);
        IResult Insert(SavedAlbumsDto savedAlbum);
        IDataResult<IEnumerable<SavedAlbumsDto>> GetAllByUserId(int userId);
    }
}

