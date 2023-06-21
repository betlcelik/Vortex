﻿using System;
using Spotify.core.dtos.AlbumDto;
using Spotify.core.dtos.ArtistDto;
using Spotify.core.dtos.UserDto;
using Spotify.entities.abstracts;
using Spotify.entities.concretes;
using SpotifyClone.Business.abstracts;
using SpotifyClone.Core.abstracts;
using SpotifyClone.Core.concretes;
using SpotifyClone.Core.Utilities.Results.Abstract;
using SpotifyClone.Core.Utilities.Results.Concretes;

namespace SpotifyClone.Business.concretes
{
	public class AlbumManager : IAlbumService
	{
        private readonly IAlbumRepository _albumRepository;

		public AlbumManager(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public IResult Delete(AlbumDto album)
        {
            _albumRepository.Delete(album);
            return new SuccessResult("Kullanıcı silindi.");
        }

        public IResult DeleteById(int id)
        {
            _albumRepository.DeleteById(id);
            return new SuccessResult("Kullanıcı silindi.");
        }

        public IDataResult<IEnumerable<AlbumDto>> GetAll()
        {
            return new SuccessDataResult<IEnumerable<AlbumDto>>(_albumRepository.GetAll(), "Kullanıcılar listelendi.");
        }

        public IDataResult<IEnumerable<AlbumDto>> GetAllByArtistId(int artistId)
        {
            return new SuccessDataResult<IEnumerable<AlbumDto>>(_albumRepository.GetAll(album => album.artistId == artistId));
        }

        public IDataResult<AlbumDto> GetById(int id)
        {
            return new SuccessDataResult<AlbumDto>(_albumRepository.GetById(id));
        }

        public IResult Insert(AlbumDto album)
        {
            DateTime currentDate = DateTime.Now.ToUniversalTime().Date;
            album.releaseDate = currentDate;
            album.totalTracks = 0;
            _albumRepository.Insert(album);
            return new SuccessResult("Albüm eklendi.");
        }

        public IResult Update(AlbumDto album)
        {
            _albumRepository.Update(album);
            return new SuccessResult("Albüm bilgileri güncellendi.");
        }
    }
}

