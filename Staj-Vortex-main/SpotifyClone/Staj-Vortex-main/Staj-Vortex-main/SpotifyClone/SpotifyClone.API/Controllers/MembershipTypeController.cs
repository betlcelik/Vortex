using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpotifyClone.Business.abstracts;
using SpotifyClone.Core.dtos.MembershipTypeDto;

namespace SpotifyClone.API.Controllers
{
    
    [Route("[controller]/[action]")]
    [ApiController]
    public class MembershipTypeController : ControllerBase
    {
        private readonly IMembershipTypeService _membershipTypeService;
        private readonly IMapper _mapper;

        public MembershipTypeController(IMembershipTypeService membershipTypeService, IMapper mapper)
        {
            _membershipTypeService = membershipTypeService;
            _mapper = mapper;
           
        }

        [HttpPost]
        public IActionResult Insert([FromBody] MembershipTypeDto membershipTypeDto)
        {
            var result = _membershipTypeService.Insert(membershipTypeDto);

            if(result.Success) { 
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result= _membershipTypeService.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _membershipTypeService.GetById(id);
            if(result.Success) { 
            
            return Ok(result);
                    }
            return BadRequest(result);
        }

    }
}
    