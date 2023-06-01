using System;
using Microsoft.AspNetCore.Mvc;
using SpotifyClone.Business.abstracts;
using SpotifyClone.Core.dtos.LikedSongsDto;
using SpotifyClone.Core.dtos.SavedSongsDto;

namespace SpotifyClone.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SavedSongsController : ControllerBase
	{
        private readonly ISavedSongsService _savedSongsService;

        public SavedSongsController(ISavedSongsService savedSongsService)
        {
            _savedSongsService = savedSongsService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _savedSongsService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetAllByUserId(int userId)
        {
            var result = _savedSongsService.GetAllByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Delete([FromBody] SavedSongsDto savedSong)
        {
            var result = _savedSongsService.Delete(savedSong);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult DeleteById(int id)
        {
            var result = _savedSongsService.DeleteById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost]
        public IActionResult Insert([FromBody] SavedSongsDto savedSong)
        {

            var result = _savedSongsService.Insert(savedSong);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _savedSongsService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

