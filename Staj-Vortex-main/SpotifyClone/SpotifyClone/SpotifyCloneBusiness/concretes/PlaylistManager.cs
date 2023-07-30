
using Spotify.core.dtos.PlaylistDto;
using SpotifyClone.Business.abstracts;
using SpotifyClone.Core.abstracts;
using SpotifyClone.Core.dtos.PlaylistSongDto;
using SpotifyClone.Core.Utilities.Results.Abstract;
using SpotifyClone.Core.Utilities.Results.Concretes;

namespace SpotifyClone.Business.concretes
{
	public class PlaylistManager : IPlaylistService
	{
        private readonly IPlaylistRepository _playlistRepository;
        private readonly IPlaylistSongService _playlistSongService;
        private readonly IUserStatisticService _userStatisticService;
        private readonly IMembershipService _membershipService;

        public PlaylistManager(IPlaylistRepository playlistRepository, IPlaylistSongService playlistSongService, IUserStatisticService userStatisticService,IMembershipService membershipService)
        {
            _playlistRepository = playlistRepository;
            _playlistSongService = playlistSongService;
            _userStatisticService = userStatisticService;
            _membershipService = membershipService;

        }

        

        public IResult Delete(PlaylistDto playlist)
        {
            _playlistRepository.Delete(playlist);
            _userStatisticService.DecrasePlayLists(playlist.userId);
            return new SuccessResult("Playlist silindi.");
        }

        public IResult DeleteById(int id)
        {
            IEnumerable<PlaylistSongDto> playlistSongs = _playlistSongService.GetAllByPlaylistId(id).Data;
            var userId = GetById(id).Data.userId;
            
            foreach(var playlistSong in playlistSongs) {
                _playlistSongService.DeleteById(playlistSong.id);
               
            }
            _userStatisticService.DecrasePlayLists(userId);
            _playlistRepository.DeleteById(id);
            return new SuccessResult("Playlist silindi.");
        }

        public IDataResult<IEnumerable<PlaylistDto>> GetAll()
        {
            return new SuccessDataResult<IEnumerable<PlaylistDto>>(_playlistRepository.GetAll(), "Playlistler listelendi.");
        }

        public IDataResult<PlaylistDto> GetById(int id)
        {
            return new SuccessDataResult<PlaylistDto>(_playlistRepository.GetById(id));
        }

        public IDataResult<IEnumerable<PlaylistDto>> GetByUserId(int userId)
        {
            
            return new SuccessDataResult<IEnumerable<PlaylistDto>>(_playlistRepository.GetAll(playlist => playlist.userId == userId));
        }

        public IResult Insert(PlaylistDto playlist)
        {
            DateTime createionDateTime = DateTime.Now.ToUniversalTime().Date;
            var membership= _membershipService.GetByUserId(playlist.userId).Data.FirstOrDefault();

            if(membership.membershipTypeId == 1)
            {
                
                var userStatistics = _userStatisticService.GetUserStatisticByUserId(playlist.userId);
                var numberOfPlaylists = userStatistics.Data.FirstOrDefault().numberOfPlaylists;
                if(numberOfPlaylists >= 5)
                {
                    return new ErrorResult("Maximum Playlist Sınırına Ulaştınız!!");
                }
                /*else
                {
                    playlist.creationDate= createionDateTime;
                    _playlistRepository.Insert(playlist);
                    _userStatisticService.IncreasePlayLists(playlist.userId);
                    return new SuccessResult("Playlist eklendi.");
                }*/
            }
            playlist.creationDate = createionDateTime;
            _playlistRepository.Insert(playlist);
            _userStatisticService.IncreasePlayLists(playlist.userId);
            return new SuccessResult("Playlist eklendi.");
        }

        public IResult Update(PlaylistDto playlist)
        {
            _playlistRepository.Update(playlist);
            return new SuccessResult("Playlist bilgileri güncellendi.");
        }

        public IResult AddSongToPlayList(PlaylistSongDto playlistSongDto)
        {
            var playlist = GetById(playlistSongDto.playlistId).Data;
            if(playlist == null)
            {
                return new ErrorResult("null döndü");
            }

            var membership=_membershipService.GetByUserId(playlist.userId).Data.FirstOrDefault();

            if(membership.membershipTypeId == 1)
            {
                if(playlist.numberOfSongs >= 25)
                {
                    return new ErrorResult("Playlist Şarkı Sayısında Maximum Sınıra Ulaştınız !!");
                }

            }

            _playlistSongService.Insert(playlistSongDto);
            playlist.numberOfSongs++;
            Update(playlist);
            return new SuccessResult("Şarkı eklendi");
        }

        public IDataResult<IEnumerable<PlaylistSongDto>> GetBySongId(int songID)
        {
            var playlists=_playlistSongService.GetAllBySongId(songID).Data;
            return new SuccessDataResult<IEnumerable<PlaylistSongDto>>(playlists,"Şarkının bulunduğu playlistler listeleniyor");
            
        }
    }
}

