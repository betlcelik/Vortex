using System;
using SpotifyClone.Business.abstracts;
using SpotifyClone.Core.abstracts;
using SpotifyClone.Core.concretes;
using SpotifyClone.Core.dtos.SavedAlbumsDto;
using SpotifyClone.Core.dtos.SavedSongsDto;
using SpotifyClone.Core.Utilities.Results.Abstract;
using SpotifyClone.Core.Utilities.Results.Concretes;

namespace SpotifyClone.Business.concretes
{
	public class SavedAlbumsManager : ISavedAlbumsService
	{
        private readonly ISavedAlbumsRepository _savedAlbumsRepository;

        public SavedAlbumsManager(ISavedAlbumsRepository savedAlbumsRepository)
        {
            _savedAlbumsRepository = savedAlbumsRepository;
        }

        public IResult Delete(SavedAlbumsDto savedAlbum)
        {
            _savedAlbumsRepository.Delete(savedAlbum);
            return new SuccessResult("Albüm kaydedilenlerden kaldırıldı.");
        }

        public IResult DeleteById(int id)
        {
            _savedAlbumsRepository.DeleteById(id);
            return new SuccessResult("Albüm kaydedilenlerden kaldırıldı.");
        }
    

        public IDataResult<IEnumerable<SavedAlbumsDto>> GetAll()
        {
            return new SuccessDataResult<IEnumerable<SavedAlbumsDto>>(_savedAlbumsRepository.GetAll(), "Listelendi.");
        }

        public IDataResult<IEnumerable<SavedAlbumsDto>> GetAllByUserId(int userId)
        {
            return new SuccessDataResult<IEnumerable<SavedAlbumsDto>>(_savedAlbumsRepository.GetAll(savedAlbum => savedAlbum.userId == userId));
        }

        public IDataResult<SavedAlbumsDto> GetById(int id)
        {
            return new SuccessDataResult<SavedAlbumsDto>(_savedAlbumsRepository.GetById(id));
        }

        public IResult Insert(SavedAlbumsDto savedAlbum)
        {
            _savedAlbumsRepository.Insert(savedAlbum);
            return new SuccessResult("Eklendi.");
        }
    }
}

