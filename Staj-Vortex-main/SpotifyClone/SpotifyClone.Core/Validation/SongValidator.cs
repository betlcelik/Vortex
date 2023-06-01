using System;
using FluentValidation;
using Spotify.core.dtos.SongDto;

namespace SpotifyClone.Core.Validation
{
	public class SongValidator : AbstractValidator<SongAddDto>
	{
		public SongValidator()
		{
			RuleFor(song => song.isrc).NotNull().Length(12);
			RuleFor(song => song.title).NotNull().Length(1, 20);
			RuleFor(song => song.genreId).NotNull();
            RuleFor(song => song.artistId).NotNull();
            RuleFor(song => song.albumId).NotNull();
            RuleFor(song => song.releaseDate).NotNull();
			//RuleFor(song => song.image);
			//RuleFor(song => song.duration)
        }
	}
}

