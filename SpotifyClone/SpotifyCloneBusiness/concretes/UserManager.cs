using System;
using System.Linq.Expressions;
using Spotify.core.dtos.UserDto;
using SpotifyClone.Business.abstracts;
using SpotifyClone.Core.abstracts;
using SpotifyClone.Core.dtos.UserDto;
using SpotifyClone.Core.Utilities.Results.Abstract;
using SpotifyClone.Core.Utilities.Results.Concretes;
using SpotifyClone.Core.Validation;

namespace SpotifyClone.Business.concretes
{
	public class UserManager : IUserService
	{

        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
		{
            _userRepository = userRepository;
		}

        public IResult Delete(UserDto user)
        {
            _userRepository.Delete(user);
            
            return new SuccessResult("Kullanıcı silindi.");
        }

        public IResult DeleteById(int id)
        {
            _userRepository.DeleteById(id);
            return new SuccessResult("Kullanıcı silindi.");
        }

        public IDataResult<IEnumerable<UserDto>> GetAll()
        {
            return new SuccessDataResult<IEnumerable<UserDto>>(_userRepository.GetAll(),"Kullanıcılar listelendi.");
        }

        public IDataResult<UserDto> GetById(int id)
        {
            return new SuccessDataResult<UserDto>(_userRepository.GetById(id));
        }


        
        public IResult Insert(UserDto user)
        {
         
            _userRepository.Insert(user);
            return new SuccessResult("Kullanıcı eklendi.");
          
        }

        public IResult Update(UserDto user)
        {

            _userRepository.Update(user);
            return new SuccessResult("Kullanıcı bilgileri güncellendi.");
          
        }

        IDataResult<UserDto> IUserService.LogIn(UserLoginDto userLoginDto)
        {
            return new SuccessDataResult<UserDto>(_userRepository.Login(userLoginDto),"Giriş başarılı");
        }
    }
}

