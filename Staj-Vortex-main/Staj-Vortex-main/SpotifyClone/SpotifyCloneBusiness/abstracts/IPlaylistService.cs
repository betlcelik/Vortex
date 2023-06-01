using System;
using Spotify.core.dtos.PlaylistDto;
using Spotify.core.dtos.UserDto;
using SpotifyClone.Core.Utilities.Results.Abstract;

namespace SpotifyClone.Business.abstracts
{
	public interface IPlaylistService
	{
        IDataResult<IEnumerable<PlaylistDto>> GetAll();
        IResult Delete(PlaylistDto playlist);
        IResult DeleteById(int id);
        IDataResult<PlaylistDto> GetById(int id);
        IResult Insert(PlaylistDto playlist);
        IResult Update(PlaylistDto playlist);
        IDataResult<IEnumerable<PlaylistDto>> GetByUserId(int userId);
    }
}

