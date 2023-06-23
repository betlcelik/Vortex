using System;
using Spotify.core.dtos.GenreDto;
using Spotify.core.dtos.SongDto;
using SpotifyClone.Core.Utilities.Results.Abstract;

namespace SpotifyClone.Business.abstracts
{
	public interface IGenreService
	{
        IDataResult<IEnumerable<GenreDto>> GetAll();
        IResult Delete(GenreDto genre);
        IResult DeleteById(int id);
        IDataResult<GenreDto> GetById(int id);
        IResult Insert(GenreDto genre);
        IResult Update(GenreDto genre);
    }
}

