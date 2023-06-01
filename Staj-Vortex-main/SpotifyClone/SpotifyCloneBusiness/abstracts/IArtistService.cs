using System;
using Spotify.core.dtos.ArtistDto;
using Spotify.core.dtos.CountryDto;
using SpotifyClone.Core.Utilities.Results.Abstract;

namespace SpotifyClone.Business.abstracts
{
	public interface IArtistService
	{
        IDataResult<IEnumerable<ArtistDto>> GetAll();
        IResult Delete(ArtistDto artist);
        IResult DeleteById(int id);
        IDataResult<ArtistDto> GetById(int id);
        IResult Insert(ArtistDto artist);
        IResult Update(ArtistDto artist);
    }
}

