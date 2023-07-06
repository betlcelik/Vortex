using System;
using System.Linq.Expressions;
using Spotify.core.dtos.UserDto;
using SpotifyClone.Core.dtos.UserDto;
using SpotifyClone.Core.Utilities.Results.Abstract;

namespace SpotifyClone.Business.abstracts
{
	public interface IUserService
	{
        IDataResult<IEnumerable<UserDto>> GetAll();
        IDataResult<IEnumerable<UserDto>> GetAllActiveUsers();
        IDataResult<IEnumerable<UserDto>> GetAllFreeUsers();
        IDataResult<IEnumerable<UserDto>> GetAllPremiumUsers();
        IDataResult<IEnumerable<UserDto>> GetAllStudentUsers();
        IResult Delete(UserDto user);
        IResult DeleteById(int id);
        IDataResult<UserDto> GetById(int id);
        IDataResult<UserDto> GetByEmail(string email);
        IDataResult<UserDto> GetByUserName(string userName);
        IResult Insert(UserDto user);
        IResult Update(UserDto user);
        IResult UpdatePassword(UserUpdatePasswordDto user);
        IDataResult<UserDto> LogIn(UserLoginDto userLoginDto);


    }
}

