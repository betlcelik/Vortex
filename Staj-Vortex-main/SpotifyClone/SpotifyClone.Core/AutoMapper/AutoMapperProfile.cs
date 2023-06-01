using System;
using AutoMapper;
using Spotify.core.dtos.AlbumDto;
using Spotify.core.dtos.ArtistDto;
using Spotify.core.dtos.CountryDto;
using Spotify.core.dtos.GenreDto;
using Spotify.core.dtos.MembershipDto;
using Spotify.core.dtos.PlaylistDto;
using Spotify.core.dtos.SongDto;
using Spotify.core.dtos.UserDto;
using SpotifyClone.Core.dtos.SongDto;
using SpotifyClone.Core.dtos.UserDto;

namespace SpotifyClone.Core.AutoMapper
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap <UserDto, UserAddDto>().ReverseMap();
            CreateMap<UserDto, UserUpdateDto>().ReverseMap();
            CreateMap<SongDto, SongAddDto>().ReverseMap();
            CreateMap<SongDto, SongUpdateDto>().PreserveReferences();
            CreateMap<SongUpdateDto, SongDto>().PreserveReferences();
            CreateMap<PlaylistDto, PlaylistAddDto>().ReverseMap();
            CreateMap<MembershipDto, MembershipAddDto>().ReverseMap();
            CreateMap<GenreDto, GenreAddDto>().ReverseMap();
            CreateMap<CountryDto, CountryAddDto>().ReverseMap();
            CreateMap<ArtistDto, ArtistAddDto>().ReverseMap();
            CreateMap<AlbumDto, AlbumAddDto>().ReverseMap();


        }
	}
}

