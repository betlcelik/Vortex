using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Spotify.core.dtos.PlaylistDto;
using Spotify.core.dtos.SongDto;
using SpotifyClone.Business.abstracts;

namespace SpotifyClone.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PlaylistController : ControllerBase
	{
		private readonly IPlaylistService _playlistService;
		private readonly IMapper _mapper;

		public PlaylistController(IPlaylistService playlistService, IMapper mapper)
		{
			_playlistService = playlistService;
			_mapper = mapper;
		}

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _playlistService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetByUserId(int id)
        {
            var result = _playlistService.GetByUserId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost]
        public IActionResult Delete([FromBody] PlaylistAddDto playlist)
        {
            var result = _playlistService.Delete(_mapper.Map<PlaylistDto>(playlist));
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult DeleteById(int id)
        {
            var result = _playlistService.DeleteById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] PlaylistAddDto playlist)
        {

            var result = _playlistService.Insert(_mapper.Map<PlaylistDto>(playlist));
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPut]
        public IActionResult Update([FromBody] PlaylistAddDto playlist)
        {
            var result = _playlistService.Update(_mapper.Map<PlaylistDto>(playlist));
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _playlistService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}

