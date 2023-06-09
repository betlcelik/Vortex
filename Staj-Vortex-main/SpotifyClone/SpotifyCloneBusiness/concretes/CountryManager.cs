﻿using System;
using Spotify.core.dtos.CountryDto;
using SpotifyClone.Business.abstracts;
using SpotifyClone.Core.abstracts;
using SpotifyClone.Core.Utilities.Results.Abstract;
using SpotifyClone.Core.Utilities.Results.Concretes;

namespace SpotifyClone.Business.concretes
{
	public class CountryManager : ICountryService
	{
        private readonly ICountryRepository _countryRepository;

		public CountryManager(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public IResult Delete(CountryDto country)
        {
            _countryRepository.Delete(country);
            return new SuccessResult("Ülke silindi.");
        }

        public IResult DeleteById(int id)
        {
            _countryRepository.DeleteById(id);
            return new SuccessResult("Ülke silindi.");
        }

        public IDataResult<IEnumerable<CountryDto>> GetAll()
        {
            return new SuccessDataResult<IEnumerable<CountryDto>>(_countryRepository.GetAll(), "Ülkeler listelendi.");
        }

        public IDataResult<CountryDto> GetById(int id)
        {
            return new SuccessDataResult<CountryDto>(_countryRepository.GetById(id));
        }

        public IResult Insert(CountryDto country)
        {
            _countryRepository.Insert(country);
            return new SuccessResult("Ülke eklendi.");
        }

        public IResult Update(CountryDto country)
        {
            _countryRepository.Update(country);
            return new SuccessResult("Ülke bilgileri güncellendi.");
        }
    }
}

