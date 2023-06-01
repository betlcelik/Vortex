using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Spotify.core.dtos.CountryDto;
using Spotify.core.dtos.GenreDto;
using SpotifyClone.Business.abstracts;

namespace SpotifyClone.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CountryController : ControllerBase
	{
		private readonly ICountryService _countryService;
		private readonly IMapper _mapper;

		public CountryController(ICountryService countryService, IMapper mapper)
		{
			_countryService = countryService;
			_mapper = mapper;
		}

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _countryService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost]
        public IActionResult Delete([FromBody] CountryAddDto country)
        {
            var result = _countryService.Delete(_mapper.Map<CountryDto>(country));
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult DeleteById(int id)
        {
            var result = _countryService.DeleteById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] CountryAddDto country)
        {

            var result = _countryService.Insert(_mapper.Map<CountryDto>(country));
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPut]
        public IActionResult Update([FromBody] CountryAddDto country)
        {
            var result = _countryService.Update(_mapper.Map<CountryDto>(country));
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _countryService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

