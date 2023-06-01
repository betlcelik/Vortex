using System;
using FluentValidation;
using SpotifyClone.Core.dtos.SavedAlbumsDto;

namespace SpotifyClone.Core.Validation
{
	public class SavedAlbumsValidator : AbstractValidator<SavedAlbumsDto>
	{
		public SavedAlbumsValidator()
		{
			RuleFor(savedAlbum => savedAlbum.albumId).NotNull();
			RuleFor(savedAlbum => savedAlbum.userId).NotNull();
		}
	}
}

