using System;
using FluentValidation;
using Spotify.core.dtos.GenreDto;

namespace SpotifyClone.Core.Validation
{
	public class GenreValidator : AbstractValidator<GenreAddDto>
	{
		public GenreValidator()
		{
			RuleFor(genre => genre.title).NotNull().Length(3, 10);
		}
	}
}

