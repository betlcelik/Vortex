using System;
using Microsoft.AspNetCore.Mvc;
using Spotify.core.dtos.PlaylistDto;
using SpotifyClone.Business.abstracts;
using SpotifyClone.Core.dtos.PlaylistSongDto;

namespace SpotifyClone.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PlaylistSongController : ControllerBase
	{
        private readonly IPlaylistSongService _playlistSongService;

        public PlaylistSongController(IPlaylistSongService playlistSongService)
        {
            _playlistSongService = playlistSongService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _playlistSongService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetAllByPlaylistId(int playlistId)
        {
            var result = _playlistSongService.GetAllByPlaylistId(playlistId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Delete([FromBody] PlaylistSongDto playlistSong)
        {
            var result = _playlistSongService.Delete(playlistSong);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult DeleteById(int id)
        {
            var result = _playlistSongService.DeleteById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost]
        public IActionResult Insert([FromBody] PlaylistSongDto playlistSong)
        {

            var result = _playlistSongService.Insert(playlistSong);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _playlistSongService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

