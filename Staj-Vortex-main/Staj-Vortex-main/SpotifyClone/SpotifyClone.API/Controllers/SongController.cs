using System;
using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Spotify.core.dtos.SongDto;
using Spotify.core.dtos.UserDto;
using SpotifyClone.Business.abstracts;
using SpotifyClone.Core.dtos.SongDto;

namespace SpotifyClone.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SongController : ControllerBase
	{
        private readonly ISongService _songService;
        private readonly IMapper _mapper;
 

        public SongController(ISongService songService, IMapper mapper)
		{
            _songService = songService;
            _mapper = mapper;
		}

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _songService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetAllByAlbumId(int albumId)
        {
            var result = _songService.GetAllByAlbumId(albumId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetAllByArtistId(int artistId)
        {
            var result = _songService.GetAllByArtistId(artistId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetAllByGenreId(int genreId)
        {
            var result = _songService.GetAllByGenreId(genreId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost]
        public IActionResult Delete([FromBody] SongAddDto song)
        {
            var result = _songService.Delete(_mapper.Map<SongDto>(song));
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult DeleteById(int id)
        {
            var result = _songService.DeleteById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] SongAddDto song)
        {

            var result = _songService.Insert(_mapper.Map<SongDto>(song));
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPut]
        public IActionResult Update([FromBody] SongUpdateDto song)
        {
            var sng = _songService.GetById(song.id).Data;
            // Mapping Eklenecek
            sng.image = song.image;
            sng.title = song.title;
            sng.duration = song.duration;
            sng.availableMarkets = song.availableMarkets;
             var result= _songService.Update(sng);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {

            var result = _songService.GetById(id);
          
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult tgazyagi()
        {
            var result = _songService.GetById(8);
            var r = JsonSerializer.Deserialize<string[]> (result.Data.availableMarkets);

            if (result.Success)
            {
                return Ok(r);
            }
            return BadRequest(result);
        }





    }
}

