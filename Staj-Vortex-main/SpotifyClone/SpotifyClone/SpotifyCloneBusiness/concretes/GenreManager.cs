using System;
using Spotify.core.dtos.GenreDto;
using Spotify.core.dtos.MembershipDto;
using Spotify.entities.abstracts;
using Spotify.entities.concretes;
using SpotifyClone.Business.abstracts;
using SpotifyClone.Core.abstracts;
using SpotifyClone.Core.concretes;
using SpotifyClone.Core.Utilities.Results.Abstract;
using SpotifyClone.Core.Utilities.Results.Concretes;

namespace SpotifyClone.Business.concretes
{
	public class GenreManager : IGenreService
	{
        private readonly IGenreRepository _genreRepository;

		public GenreManager(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public IResult Delete(GenreDto genre)
        {
            _genreRepository.Delete(genre);
            return new SuccessResult("Müzik türü silindi.");
        }

        public IResult DeleteById(int id)
        {
            _genreRepository.DeleteById(id);
            return new SuccessResult("Müzik türü  silindi.");
        }

        public IDataResult<IEnumerable<GenreDto>> GetAll()
        {
            return new SuccessDataResult<IEnumerable<GenreDto>>(_genreRepository.GetAll(), "Müzik türü  listelendi.");
        }

        public IDataResult<GenreDto> GetById(int id)
        {
            
            return new SuccessDataResult<GenreDto>(_genreRepository.GetById(id));
        }

        public IResult Insert(GenreDto genre)
        {
            _genreRepository.Insert(genre);
            return new SuccessResult("Müzik türü  eklendi.");
        }

        public IResult Update(GenreDto genre)
        {
            _genreRepository.Update(genre);
            return new SuccessResult("Müzik türü  bilgileri güncellendi.");
        }
    }
}

