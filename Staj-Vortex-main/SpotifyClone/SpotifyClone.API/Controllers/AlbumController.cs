using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Spotify.core.dtos.AlbumDto;
using Spotify.core.dtos.ArtistDto;
using SpotifyClone.Business.abstracts;

namespace SpotifyClone.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AlbumController : ControllerBase
	{
		private readonly IAlbumService _albumService;
		private readonly IMapper _mapper;

		public AlbumController(IAlbumService albumService, IMapper mapper)
		{
			_albumService = albumService;
			_mapper = mapper;
		}

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _albumService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetAllByArtistId(int artistId)
        {
            var result = _albumService.GetAllByArtistId(artistId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetAllByGenreId(int genreId)
        {
            var result = _albumService.GetAllByGenreId(genreId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost]
        public IActionResult Delete([FromBody] AlbumAddDto album)
        {
            var result = _albumService.Delete(_mapper.Map<AlbumDto>(album));
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult DeleteById(int id)
        {
            var result = _albumService.DeleteById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] AlbumAddDto album)
        {

            var result = _albumService.Insert(_mapper.Map<AlbumDto>(album));
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPut]
        public IActionResult Update([FromBody] AlbumAddDto album)
        {
            var result = _albumService.Update(_mapper.Map<AlbumDto>(album));
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _albumService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

