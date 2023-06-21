using System;
using SpotifyClone.Business.abstracts;
using SpotifyClone.Core.abstracts;
using SpotifyClone.Core.concretes;
using SpotifyClone.Core.dtos.LikedSongsDto;
using SpotifyClone.Core.dtos.PlaylistSongDto;
using SpotifyClone.Core.dtos.UserStatisticDto;
using SpotifyClone.Core.Utilities.Results.Abstract;
using SpotifyClone.Core.Utilities.Results.Concretes;
using SpotifyClone.Entities.abstracts;
using SpotifyClone.Entities.concretes;

namespace SpotifyClone.Business.concretes
{
    public class LikedSongsManager : ILikedSongsService
    {
        private readonly ILikedSongsRepository _likedSongsRepository;
        private readonly IUserStatisticService _userStatisticService;

        public LikedSongsManager(ILikedSongsRepository likedSongsRepository, IUserStatisticService userStatisticService)
        {
            _likedSongsRepository = likedSongsRepository;
            _userStatisticService = userStatisticService;
        }

        public IResult Delete(LikedSongsWithoutIdDto likedSong)
        {

         LikedSongsDto itemToDelete = GetAllByUserId(likedSong.userId).Data.FirstOrDefault(liked => liked.songId == likedSong.songId);
              
            _userStatisticService.DecraseLikedSongs(likedSong.userId);
            _likedSongsRepository.Delete(itemToDelete);
            return new SuccessResult("Şarkı beğenilerden kaldırıldı.");
        }

        public IResult DeleteById(int id)
        {
            var likedSong = _likedSongsRepository.GetById(id);
            _userStatisticService.DecraseLikedSongs(likedSong.userId);
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
            _userStatisticService.IncreaseLikedSongs(likedSong.userId);
            return new SuccessResult("Eklendi.");
        }
    }
}

