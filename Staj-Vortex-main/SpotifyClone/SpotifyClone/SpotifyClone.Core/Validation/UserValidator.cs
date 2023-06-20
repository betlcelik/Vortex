using System;
using FluentValidation;
using Spotify.core.dtos.UserDto;
using Spotify.entities.concretes;
using SpotifyClone.Core.concretes;

namespace SpotifyClone.Core.Validation
{
	public class UserValidator : AbstractValidator<UserAddDto>
	{
		public UserValidator()
		{
	
			RuleFor(user => user.userName).NotNull().Length(3, 15);
			RuleFor(user => user.password)
				.NotNull()
				.MinimumLength(6)
				.Matches("[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir.")
				.Matches("[a-z]").WithMessage("Şifre en az bir küçük harf içermelidir.")
				.Matches("[0-9]").WithMessage("Şifre en az bir rakam içermelidir.");
			RuleFor(user => user.email).NotNull().EmailAddress();
			RuleFor(user => user.countryId).NotNull();

		}
	}
}

