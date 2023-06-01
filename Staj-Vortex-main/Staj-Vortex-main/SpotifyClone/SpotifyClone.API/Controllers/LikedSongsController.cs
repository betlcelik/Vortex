using System;
using Microsoft.AspNetCore.Mvc;
using SpotifyClone.Business.abstracts;
using SpotifyClone.Core.dtos.LikedSongsDto;
using SpotifyClone.Core.dtos.PlaylistSongDto;

namespace SpotifyClone.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class LikedSongsController : ControllerBase
	{
        private readonly ILikedSongsService _likedSongsService;

        public LikedSongsController(ILikedSongsService likedSongsService)
        {
            _likedSongsService = likedSongsService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _likedSongsService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetAllByUserId(int userId)
        {
            var result = _likedSongsService.GetAllByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Delete([FromBody] LikedSongsDto likedSong)
        {
            var result = _likedSongsService.Delete(likedSong);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult DeleteById(int id)
        {
            var result = _likedSongsService.DeleteById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost]
        public IActionResult Insert([FromBody] LikedSongsDto likedSong)
        {

            var result = _likedSongsService.Insert(likedSong);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _likedSongsService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

