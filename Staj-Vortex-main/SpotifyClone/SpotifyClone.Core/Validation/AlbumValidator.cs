﻿using System;
using FluentValidation;
using Spotify.core.dtos.AlbumDto;

namespace SpotifyClone.Core.Validation
{
	public class AlbumValidator : AbstractValidator<AlbumAddDto>
	{
		public AlbumValidator()
		{
			RuleFor(album => album.title).NotNull().Length(3, 20);
			RuleFor(album => album.artistId).NotNull();
			RuleFor(album => album.image).NotNull();

		}
	}
}

