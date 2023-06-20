using System;
using Spotify.core.dtos.AlbumDto;
using Spotify.core.dtos.UserDto;
using SpotifyClone.Core.Utilities.Results.Abstract;

namespace SpotifyClone.Business.abstracts
{
	public interface IAlbumService
	{
        IDataResult<IEnumerable<AlbumDto>> GetAll();
        IResult Delete(AlbumDto album);
        IResult DeleteById(int id);
        IDataResult<AlbumDto> GetById(int id);
        IResult Insert(AlbumDto album);
        IResult Update(AlbumDto album);
        IDataResult<IEnumerable<AlbumDto>> GetAllByArtistId(int artistId);
        IDataResult<IEnumerable<AlbumDto>> GetAllByGenreId(int genreId);
    }
}

