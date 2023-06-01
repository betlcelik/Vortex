using System;
using SpotifyClone.Business.abstracts;
using SpotifyClone.Core.abstracts;
using SpotifyClone.Core.concretes;
using SpotifyClone.Core.dtos.LikedSongsDto;
using SpotifyClone.Core.dtos.SavedSongsDto;
using SpotifyClone.Core.Utilities.Results.Abstract;
using SpotifyClone.Core.Utilities.Results.Concretes;

namespace SpotifyClone.Business.concretes
{
	public class SavedSongsManager : ISavedSongsService
	{

        private readonly ISavedSongsRepository _savedSongsRepository;


        public IResult Delete(SavedSongsDto savedSong)
        {
            _savedSongsRepository.Delete(savedSong);
            return new SuccessResult("Şarkı kaydedilenlerden kaldırıldı.");
        }

        public IResult DeleteById(int id)
        {
            _savedSongsRepository.DeleteById(id);
            return new SuccessResult("Şarkı kaydedilenlerden kaldırıldı.");
        }

        public IDataResult<IEnumerable<SavedSongsDto>> GetAll()
        {
            return new SuccessDataResult<IEnumerable<SavedSongsDto>>(_savedSongsRepository.GetAll(), "Listelendi.");
        }

        public IDataResult<IEnumerable<SavedSongsDto>> GetAllByUserId(int userId)
        {
            return new SuccessDataResult<IEnumerable<SavedSongsDto>>(_savedSongsRepository.GetAll(savedSong => savedSong.userId == userId));
        }

        public IDataResult<SavedSongsDto> GetById(int id)
        {
            return new SuccessDataResult<SavedSongsDto>(_savedSongsRepository.GetById(id));
        }

        public IResult Insert(SavedSongsDto savedSong)
        {
            _savedSongsRepository.Insert(savedSong);
            return new SuccessResult("Eklendi.");
        }
    }
}

