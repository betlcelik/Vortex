using System;
using FluentValidation;
using SpotifyClone.Core.dtos.PlaylistSongDto;

namespace SpotifyClone.Core.Validation
{
	public class PlaylistSongValidator : AbstractValidator<PlaylistSongDto>
	{
		public PlaylistSongValidator()
		{
			RuleFor(playlistSong => playlistSong.playlistId).NotNull();
            RuleFor(playlistSong => playlistSong.songId).NotNull();
        }
	}
}

