using System;
using FluentValidation;
using SpotifyClone.Core.dtos.LikedSongsDto;

namespace SpotifyClone.Core.Validation
{
	public class LikedSongsValidator : AbstractValidator<LikedSongsDto>
	{
		public LikedSongsValidator()
		{
			RuleFor(likedSong => likedSong.songId).NotNull();
			RuleFor(likedSong => likedSong.userId).NotNull();
		}
	}
}

