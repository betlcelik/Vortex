using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Spotify.core.dtos.GenreDto;
using Spotify.core.dtos.MembershipDto;
using SpotifyClone.Business.abstracts;

namespace SpotifyClone.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class GenreController : ControllerBase
	{
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

		public GenreController(IGenreService genreService, IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _genreService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost]
        public IActionResult Delete([FromBody] GenreAddDto genre)
        {
            var result = _genreService.Delete(_mapper.Map<GenreDto>(genre));
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult DeleteById(int id)
        {
            var result = _genreService.DeleteById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] GenreAddDto genre)
        {

            var result = _genreService.Insert(_mapper.Map<GenreDto>(genre));
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPut]
        public IActionResult Update([FromBody] GenreAddDto genre)
        {
            var result = _genreService.Update(_mapper.Map<GenreDto>(genre));
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _genreService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

