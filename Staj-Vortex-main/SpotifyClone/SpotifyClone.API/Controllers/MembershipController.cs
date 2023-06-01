using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Spotify.core.dtos.MembershipDto;
using Spotify.core.dtos.PlaylistDto;
using SpotifyClone.Business.abstracts;

namespace SpotifyClone.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MembershipController : ControllerBase
	{
		private readonly IMembershipService _membershipService;
		private readonly IMapper _mapper;

		public MembershipController(IMembershipService membershipService, IMapper mapper)
		{
			_membershipService = membershipService;
			_mapper = mapper;
		}

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _membershipService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost]
        public IActionResult Delete([FromBody] MembershipAddDto membership)
        {
            var result = _membershipService.Delete(_mapper.Map<MembershipDto>(membership));
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult DeleteById(int id)
        {
            var result = _membershipService.DeleteById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] MembershipAddDto membership)
        {

            var result = _membershipService.Insert(_mapper.Map<MembershipDto>(membership));
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPut]
        public IActionResult Update([FromBody] MembershipAddDto membership)
        {
            var result = _membershipService.Update(_mapper.Map<MembershipDto>(membership));
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _membershipService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

