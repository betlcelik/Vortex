using System;
using FluentValidation;
using SpotifyClone.Core.dtos.SavedSongsDto;

namespace SpotifyClone.Core.Validation
{
	public class SavedSongsValidator : AbstractValidator<SavedSongsDto>
	{
		public SavedSongsValidator()
		{
			RuleFor(savedSong => savedSong.songId).NotNull();
			RuleFor(savedSong => savedSong.userId).NotNull();
		}
	}
}

