using System;
using FluentValidation;
using Spotify.core.dtos.MembershipDto;

namespace SpotifyClone.Core.Validation
{
	public class MembershipValidator : AbstractValidator<MembershipAddDto>
	{
		public MembershipValidator()
		{
			RuleFor(membership => membership.type).NotNull().Length(3, 10);
			RuleFor(membership => membership.price).NotNull().GreaterThan(0);
			RuleFor(membership => membership.userId).NotNull();
		}
	}
}

