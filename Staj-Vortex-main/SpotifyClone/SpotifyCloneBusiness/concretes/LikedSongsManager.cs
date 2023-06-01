using System;
using SpotifyClone.Business.abstracts;
using SpotifyClone.Core.abstracts;
using SpotifyClone.Core.concretes;
using SpotifyClone.Core.dtos.LikedSongsDto;
using SpotifyClone.Core.dtos.PlaylistSongDto;
using SpotifyClone.Core.Utilities.Results.Abstract;
using SpotifyClone.Core.Utilities.Results.Concretes;
using SpotifyClone.Entities.abstracts;
using SpotifyClone.Entities.concretes;

namespace SpotifyClone.Business.concretes
{
    public class LikedSongsManager : ILikedSongsService
    {
        private readonly ILikedSongsRepository _likedSongsRepository;

        public LikedSongsManager(ILikedSongsRepository likedSongsRepository)
        {
            _likedSongsRepository = likedSongsRepository;
        }

        public IResult Delete(LikedSongsDto likedSong)
        {
            _likedSongsRepository.Delete(likedSong);
            return new SuccessResult("Şarkı beğenilerden kaldırıldı.");
        }

        public IResult DeleteById(int id)
        {
            _likedSongsRepository.DeleteById(id);
            return new SuccessResult("Şarkı beğenilerden kaldırıldı.");
        }

        public IDataResult<IEnumerable<LikedSongsDto>> GetAll()
        {
            return new SuccessDataResult<IEnumerable<LikedSongsDto>>(_likedSongsRepository.GetAll(), "Listelendi.");
        }

        public IDataResult<IEnumerable<LikedSongsDto>> GetAllByUserId(int userId)
        {
            return new SuccessDataResult<IEnumerable<LikedSongsDto>>(_likedSongsRepository.GetAll(likedSong => likedSong.userId == userId));
        }

        public IDataResult<LikedSongsDto> GetById(int id)
        {
            return new SuccessDataResult<LikedSongsDto>(_likedSongsRepository.GetById(id));
        }

        public IResult Insert(LikedSongsDto likedSong)
        {
            _likedSongsRepository.Insert(likedSong);
            return new SuccessResult("Eklendi.");
        }
    }
}

