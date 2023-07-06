using Microsoft.AspNetCore.Mvc;
using Spotify.core.dtos.UserDto;
using SpotifyClone.Core.abstracts;
using SpotifyClone.Business.abstracts;
using AutoMapper;
using SpotifyClone.Core.dtos.UserDto;

using SpotifyClone.Core.Validation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpotifyClone.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

       
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet]
        public IActionResult GetAllActiveUsers()
        {
            var result = _userService.GetAllActiveUsers();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetAllFreeUsers()
        {
            var result=_userService.GetAllFreeUsers();
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
        [HttpGet]
        public IActionResult GetAllPremiumUsers()
        {
            var result= _userService.GetAllPremiumUsers();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet]
        public IActionResult GetAllStudentUsers()
        {
            var result=_userService.GetAllStudentUsers();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Delete([FromBody] UserAddDto user) {
            var result = _userService.Delete(_mapper.Map<UserDto>(user));
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult DeleteById(int id) {
            var result = _userService.DeleteById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        
        public IActionResult Insert([FromBody] UserAddDto user) {

            var result = _userService.Insert(_mapper.Map<UserDto>(user));
            
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPut]
        public IActionResult Update([FromBody] UserUpdateDto user) {
            var result = _userService.Update(_mapper.Map<UserDto>(user));
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult UpdatePassword([FromBody] UserUpdatePasswordDto user)
        {
            var result = _userService.UpdatePassword(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetById(int id) {
            var result = _userService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult LogIn(UserLoginDto user)
        {
            var result=_userService.LogIn(_mapper.Map<UserLoginDto>(user));
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result) ;
        }
    }
}
