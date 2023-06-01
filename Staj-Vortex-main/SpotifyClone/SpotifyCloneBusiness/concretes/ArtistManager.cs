using System;
using Spotify.core.dtos.ArtistDto;
using Spotify.core.dtos.CountryDto;
using Spotify.entities.concretes;
using SpotifyClone.Business.abstracts;
using SpotifyClone.Core.abstracts;
using SpotifyClone.Core.concretes;
using SpotifyClone.Core.Utilities.Results.Abstract;
using SpotifyClone.Core.Utilities.Results.Concretes;

namespace SpotifyClone.Business.concretes
{
	public class ArtistManager : IArtistService
	{
        private readonly IArtistRepository _artistRepository;

		public ArtistManager(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public IResult Delete(ArtistDto artist)
        {
            _artistRepository.Delete(artist);
            return new SuccessResult("Kullanıcı silindi.");
        }

        public IResult DeleteById(int id)
        {
            _artistRepository.DeleteById(id);
            return new SuccessResult("Kullanıcı silindi.");
        }

        public IDataResult<IEnumerable<ArtistDto>> GetAll()
        {
            return new SuccessDataResult<IEnumerable<ArtistDto>>(_artistRepository.GetAll(), "Kullanıcılar listelendi.");
        }

        public IDataResult<ArtistDto> GetById(int id)
        {
            return new SuccessDataResult<ArtistDto>(_artistRepository.GetById(id));
        }

        public IResult Insert(ArtistDto artist)
        {
            _artistRepository.Insert(artist);
            return new SuccessResult("Kullanıcı eklendi.");
        }

        public IResult Update(ArtistDto artist)
        {
            _artistRepository.Update(artist);
            return new SuccessResult("Kullanıcı bilgileri güncellendi.");
        }
    }
}

