using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Spotify.core.dtos.ArtistDto;
using Spotify.core.dtos.CountryDto;
using SpotifyClone.Business.abstracts;

namespace SpotifyClone.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ArtistController : ControllerBase
	{
		private readonly IArtistService _artistService;
		private readonly IMapper _mapper;

		public ArtistController(IArtistService artistService, IMapper mapper)
		{
			_artistService = artistService;
			_mapper = mapper;
		}

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _artistService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost]
        public IActionResult Delete([FromBody] ArtistAddDto artist)
        {
            var result = _artistService.Delete(_mapper.Map<ArtistDto>(artist));
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult DeleteById(int id)
        {
            var result = _artistService.DeleteById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] ArtistAddDto artist)
        {

            var result = _artistService.Insert(_mapper.Map<ArtistDto>(artist));
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPut]
        public IActionResult Update([FromBody] ArtistAddDto artist)
        {
            var result = _artistService.Update(_mapper.Map<ArtistDto>(artist));
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _artistService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

