using System;
using FluentValidation;
using Spotify.core.dtos.MembershipDto;

namespace SpotifyClone.Core.Validation
{
	public class MembershipValidator : AbstractValidator<MembershipAddDto>
	{
		public MembershipValidator()
		{
			
			RuleFor(membership => membership.userId).NotNull();
		}
	}
}

