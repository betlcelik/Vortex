using System;
using Spotify.core.dtos.PlaylistDto;
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
    public class PlaylistSongManager : IPlaylistSongService
    {
        private readonly IPlaylistSongRepository _playlistSongRepository;
        private readonly IMembershipService _membershipService;
       

        public PlaylistSongManager(IPlaylistSongRepository playlistSongRepository, IMembershipService membershipService
            )
        {
            _playlistSongRepository = playlistSongRepository;
            _membershipService = membershipService;
           
           
        }

        public IResult Delete(PlaylistSongDto playlistSong)
        {
            _playlistSongRepository.Delete(playlistSong);
            return new SuccessResult("Şarkı listeden kaldırıldı.");
        }

        public IResult DeleteById(int id)
        {
            _playlistSongRepository.DeleteById(id);
            return new SuccessResult("Şarkı listeden kaldırıldı.");
        }

        public IDataResult<IEnumerable<PlaylistSongDto>> GetAll()
        {
            return new SuccessDataResult<IEnumerable<PlaylistSongDto>>(_playlistSongRepository.GetAll(), "Listelendi.");
        }

        public IDataResult<IEnumerable<PlaylistSongDto>> GetAllByPlaylistId(int playlistId)
        {
            return new SuccessDataResult<IEnumerable<PlaylistSongDto>>(_playlistSongRepository.GetAll(playlistSong => playlistSong.playlistId == playlistId));
        }

        public IDataResult<IEnumerable<PlaylistSongDto>> GetAllBySongId(int songId)
        {
            return new SuccessDataResult<IEnumerable<PlaylistSongDto>>(_playlistSongRepository.GetAll(playlist => playlist.songId == songId));
        }

        public IDataResult<PlaylistSongDto> GetById(int id)
        {
            return new SuccessDataResult<PlaylistSongDto>(_playlistSongRepository.GetById(id));
        }

        public IResult Insert(PlaylistSongDto playlistSong)
        {
             
            _playlistSongRepository.Insert(playlistSong);
            return new SuccessResult("Eklendi.");
        }
    }
}

