using System;
using System.Text.Json;
using Spotify.core.dtos.CountryDto;
using Spotify.core.dtos.SongDto;
using Spotify.core.dtos.UserDto;
using Spotify.entities.abstracts;
using Spotify.entities.concretes;
using SpotifyClone.Business.abstracts;
using SpotifyClone.Core.abstracts;
using SpotifyClone.Core.concretes;
using SpotifyClone.Core.Utilities.Results.Abstract;
using SpotifyClone.Core.Utilities.Results.Concretes;

namespace SpotifyClone.Business.concretes
{
	public class SongManager : ISongService
	{
        private readonly ISongRepository _songRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ICountryService _countryService;
        private readonly IUserService _userService;

        public SongManager(ISongRepository songRepository, ICountryService countryService, ICountryRepository countryRepository, IUserService userService)
        {
            _songRepository = songRepository;
            _countryService = countryService;
            _countryRepository = countryRepository;
            _userService = userService;

        }

        public IResult Delete(SongDto song)
        {
            _songRepository.Delete(song);
            return new SuccessResult("Kullanıcı silindi.");
        }

        public IResult DeleteById(int id)
        {
            _songRepository.DeleteById(id);
            return new SuccessResult("Kullanıcı silindi.");
        }

        public IDataResult<IEnumerable<SongDto>> GetAll()
        {

            return new SuccessDataResult<IEnumerable<SongDto>>(_songRepository.GetAll(), "Kullanıcılar listelendi.");
        }

        public IDataResult<IEnumerable<SongDto>> GetAllByAlbumId(int albumId)
        {
            return new SuccessDataResult<IEnumerable<SongDto>>(_songRepository.GetAll(song => song.albumId == albumId));
        }

        public IDataResult<IEnumerable<SongDto>> GetAllByArtistId(int artistId)
        {
            return new SuccessDataResult<IEnumerable<SongDto>>(_songRepository.GetAll(song => song.artistId == artistId));
        }

        public IDataResult<IEnumerable<SongDto>> GetAllByGenreId(int genreId)
        {
            return new SuccessDataResult<IEnumerable<SongDto>>(_songRepository.GetAll(song => song.genreId == genreId));
        }

        public IDataResult<SongDto> GetById(int id)
        {
            SongDto song = _songRepository.GetById(id);
          
          
            return new SuccessDataResult<SongDto>(song);
        }

        public IDataResult<IEnumerable<SongDto>> GetSongsForUser(int userId)
        {
            int count = 0;
            var userCountryId=_userService.GetById(userId).Data.countryId;
            IEnumerable<SongDto> songsToList = new List<SongDto>();
            var songs= _songRepository.GetAll();
            foreach (SongDto song in songs)
            {
                var marketList=song.availableMarkets.Split(",").ToList();
               
                if (marketList.Contains(userCountryId.ToString()))
                {
                   songsToList= songsToList.Append(song).ToList();
                    //return new SuccessDataResult<IEnumerable<SongDto>>(songsToList, "Şarkılar Listeleniyor .......... "+song.id);
                }
            }

            foreach (SongDto song in songsToList)
            {
                count++;
            }
            return new SuccessDataResult<IEnumerable<SongDto>>(songsToList,"Şarkılar Listeleniyor"+count+"country " +userCountryId);
        }

        public IResult Insert(SongDto song)
        {
            var marketlist=song.availableMarkets.Split(",").ToList();
            foreach (var item in marketlist)
            {
                if(_countryService.GetById(Convert.ToInt32(item)).Data == null) {
                    throw new ArgumentException($"Market id {item} is not valid.");
                }
            }
            //string json = JsonSerializer.Serialize(marketlist);
            string availableMarkets = string.Join(",", marketlist);
            song.availableMarkets = availableMarkets;
            //song.availableMarkets = json;

            _songRepository.Insert(song);

            return new SuccessResult("Kullanıcı eklendi.");
        }

        public IResult Update(SongDto song)
        {

            _songRepository.Update(song);
            return new SuccessResult("Kullanıcı bilgileri güncellendi.");
        }
    }
}

