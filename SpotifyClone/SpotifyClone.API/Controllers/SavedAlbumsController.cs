using System;
using Microsoft.AspNetCore.Mvc;
using SpotifyClone.Business.abstracts;
using SpotifyClone.Core.dtos.SavedAlbumsDto;
using SpotifyClone.Core.dtos.SavedSongsDto;

namespace SpotifyClone.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SavedAlbumsController : ControllerBase
	{
        private readonly ISavedAlbumsService _savedAlbumsService ;

        public SavedAlbumsController(ISavedAlbumsService savedAlbumsService)
        {
            _savedAlbumsService = savedAlbumsService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _savedAlbumsService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetAllByUserId(int userId)
        {
            var result = _savedAlbumsService.GetAllByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost]
        public IActionResult Delete([FromBody] SavedAlbumsDto savedAlbum)
        {
            var result = _savedAlbumsService.Delete(savedAlbum);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult DeleteById(int id)
        {
            var result = _savedAlbumsService.DeleteById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost]
        public IActionResult Insert([FromBody] SavedAlbumsDto savedAlbum)
        {

            var result = _savedAlbumsService.Insert(savedAlbum);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _savedAlbumsService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

