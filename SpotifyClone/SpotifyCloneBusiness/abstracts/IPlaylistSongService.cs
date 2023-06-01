using System;
using SpotifyClone.Core.dtos.PlaylistSongDto;
using SpotifyClone.Core.Utilities.Results.Abstract;

namespace SpotifyClone.Business.abstracts
{
	public interface IPlaylistSongService
	{
        IDataResult<IEnumerable<PlaylistSongDto>> GetAll();
        IResult Delete(PlaylistSongDto playlistSong);
        IResult DeleteById(int id);
        IDataResult<PlaylistSongDto> GetById(int id);
        IResult Insert(PlaylistSongDto playlistSong);
        IDataResult<IEnumerable<PlaylistSongDto>> GetAllByPlaylistId(int playlistId);

    }
}

