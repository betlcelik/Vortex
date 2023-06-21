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
using SpotifyClone.Core.dtos.PlaylistSongDto;
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
        private readonly IAlbumService _albumService;
        private readonly IPlaylistSongService _playlistSongService;
        private readonly ILikedSongsService _likedSongsService;
      

        public SongManager(ISongRepository songRepository, ICountryService countryService, ICountryRepository countryRepository, IUserService userService, IAlbumService albumService,IPlaylistSongService playlistSongService, ILikedSongsService likedSongsService)
        {
            _songRepository = songRepository;
            _countryService = countryService;
            _countryRepository = countryRepository;
            _userService = userService;
            _albumService = albumService;
            _playlistSongService = playlistSongService;
            _likedSongsService = likedSongsService;
           
        }

        public IResult Delete(SongDto song)
        {
            _songRepository.Delete(song);
            return new SuccessResult("Kullanıcı silindi.");
        }

        public IResult DeleteById(int id)
        {       
            

            var song= _songRepository.GetById(id);
            var album = _albumService.GetById(song.albumId).Data;
            var playlistsongs=_playlistSongService.GetAllBySongId(song.id).Data;
            var likedSongs = _likedSongsService.GetAllBySongId(song.id).Data;

            foreach (var likedSong in likedSongs)
            {
               
                _likedSongsService.DeleteById(likedSong.id);
            }

            foreach (var playlistSong in playlistsongs)
            {
                if(playlistSong != null)
                {
                    _playlistSongService.DeleteById(playlistSong.id);
                }
                
                
            }

            _songRepository.DeleteById(id);
            album.totalTracks--;
            _albumService.Update(album);
            return new SuccessResult("Şarkı silindi.");
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
            DateTime currentDate = DateTime.Now.ToUniversalTime().Date;
            var marketlist=song.availableMarkets.Split(",").ToList();
            var album = _albumService.GetById(song.albumId).Data;
            
            foreach (var item in marketlist)
            {
                if(_countryService.GetById(Convert.ToInt32(item)).Data == null) {
                    throw new ArgumentException($"Market id {item} is not valid.");
                }
            }
            
            string availableMarkets = string.Join(",", marketlist);
            song.availableMarkets = availableMarkets;
            song.releaseDate = currentDate;
            _songRepository.Insert(song);

            album.totalTracks++;
            _albumService.Update(album);
            return new SuccessResult("Şarkı eklendi.");
        }

        public IResult Update(SongDto song)
        {

            _songRepository.Update(song);
            return new SuccessResult("Kullanıcı bilgileri güncellendi.");
        }
    }
}

