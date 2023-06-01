using System;
using Spotify.core.dtos.SongDto;
using Spotify.core.dtos.UserDto;
using SpotifyClone.Core.Utilities.Results.Abstract;

namespace SpotifyClone.Business.abstracts
{
	public interface ISongService
	{
        IDataResult<IEnumerable<SongDto>> GetAll();
        IResult Delete(SongDto song);
        IResult DeleteById(int id);
        IDataResult<SongDto> GetById(int id);
        IResult Insert(SongDto song);
        IResult Update(SongDto song);
        IDataResult<IEnumerable<SongDto>> GetAllByArtistId(int artistId);
        IDataResult<IEnumerable<SongDto>> GetAllByAlbumId(int albumId);
        IDataResult<IEnumerable<SongDto>> GetAllByGenreId(int genreId);


    }
}

