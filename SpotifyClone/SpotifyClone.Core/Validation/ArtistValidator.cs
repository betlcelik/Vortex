using System;
using FluentValidation;
using Spotify.core.dtos.ArtistDto;

namespace SpotifyClone.Core.Validation
{
	public class ArtistValidator : AbstractValidator<ArtistAddDto>
	{
		public ArtistValidator()
		{
			RuleFor(artist => artist.fullName).NotNull().Length(1, 20);
			RuleFor(artist => artist.about).NotNull().Length(0, 50);
			RuleFor(artist => artist.image).NotNull();
		}
	}
}

