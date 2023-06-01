using System;
using FluentValidation;
using Spotify.core.dtos.CountryDto;

namespace SpotifyClone.Core.Validation
{
	public class CountryValidator : AbstractValidator<CountryAddDto>
	{
		public CountryValidator()
		{
			RuleFor(country => country.countryName).NotNull().Length(2, 15);
		}
	}
}

