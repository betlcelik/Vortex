using System;
using System.Linq.Expressions;
using Spotify.core.dtos.PlaylistDto;
using Spotify.core.dtos.SongDto;
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
	public class PlaylistManager : IPlaylistService
	{
        private readonly IPlaylistRepository _playlistRepository;
        private readonly IPlaylistSongService _playlistSongService;

        public PlaylistManager(IPlaylistRepository playlistRepository, IPlaylistSongService playlistSongService)
        {
            _playlistRepository = playlistRepository;
            _playlistSongService = playlistSongService;
        }

        public IResult Delete(PlaylistDto playlist)
        {
            _playlistRepository.Delete(playlist);
            return new SuccessResult("Kullanıcı silindi.");
        }

        public IResult DeleteById(int id)
        {
            IEnumerable<PlaylistSongDto> playlistSongs = _playlistSongService.GetAllByPlaylistId(id).Data;
            foreach(var playlistSong in playlistSongs) {
                _playlistSongService.DeleteById(playlistSong.id);
            }

            _playlistRepository.DeleteById(id);
            return new SuccessResult("Kullanıcı silindi.");
        }

        public IDataResult<IEnumerable<PlaylistDto>> GetAll()
        {
            return new SuccessDataResult<IEnumerable<PlaylistDto>>(_playlistRepository.GetAll(), "Kullanıcılar listelendi.");
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
            _playlistRepository.Insert(playlist);
            return new SuccessResult("Kullanıcı eklendi.");
        }

        public IResult Update(PlaylistDto playlist)
        {
            _playlistRepository.Update(playlist);
            return new SuccessResult("Kullanıcı bilgileri güncellendi.");
        }
    }
}

