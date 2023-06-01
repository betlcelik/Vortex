using System;
using Spotify.core.dtos.CountryDto;
using SpotifyClone.Core.Utilities.Results.Abstract;

namespace SpotifyClone.Business.abstracts
{
	public interface ICountryService
	{
        IDataResult<IEnumerable<CountryDto>> GetAll();
        IResult Delete(CountryDto country);
        IResult DeleteById(int id);
        IDataResult<CountryDto> GetById(int id);
        IResult Insert(CountryDto country);
        IResult Update(CountryDto country);
    }
}

