using System;
using FluentValidation;
using Spotify.core.dtos.PlaylistDto;

namespace SpotifyClone.Core.Validation
{
	public class PlaylistValidator : AbstractValidator<PlaylistAddDto>
	{
		public PlaylistValidator()
		{
			RuleFor(playlist => playlist.userId).NotNull();
		}
	}
}

