﻿using System;
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
            var _user = _userRepository.GetById(user.id);
            user.password = _user.password;
            _userRepository.Update(user);
            
            return new SuccessResult("Kullanıcı bilgileri güncellendi.");
          
        }

        IDataResult<UserDto> IUserService.LogIn(UserLoginDto userLoginDto)
        {

            if(userLoginDto != null)
            {
                UserDto user = _userRepository.Get(user =>
                (user.userName == userLoginDto.loginCredential || user.email == userLoginDto.loginCredential) &&
                    user.password == userLoginDto.password);

                if (user != null)
                {
                    return new SuccessDataResult<UserDto>(user, "Giriş başarılı");
                }

                else
                {
                    return new ErrorDataResult<UserDto>(null, "Bilgileri eksik veya hatalı girdiniz");
                }

            }
            else
            {
                return new ErrorDataResult<UserDto>(null, "Gerekli alanları dolduruğunuzdan emin olun ");
            }
            

            

           
        }

        IResult IUserService.UpdatePassword(UserUpdatePasswordDto user)
        {
            var _user= _userRepository.GetById(user.id);
            if(user != null && _user!= null)
            {
                if (_user.password.Equals(user.oldPassword) )
                {
                    if (user.newPassword.Equals(user.newPasswordRepeat))
                    {
                        _user.password = user.newPassword;
                        _userRepository.Update(_user);
                        return new SuccessResult("Şifre güncellendi");
                    }
                    return new ErrorResult("Giridiğiniz şifreler uyuşmuyor");
                }

                return new ErrorResult("Eksik ya da hatalı bilgi girdiniz");
                
            }

            return new ErrorResult("Eksik ya da hatalı bilgi");
        }
    }
}

