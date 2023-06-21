using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SpotifyClone.Business.abstracts;
using SpotifyClone.Core.dtos.UserStatisticDto;

namespace SpotifyClone.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserStatisticController : ControllerBase
    {
        private readonly IUserStatisticService _userStatisticService;
        private readonly IMapper _mapper;

        public UserStatisticController(IUserStatisticService userStatisticService,IMapper mapper)
        {
             _userStatisticService = userStatisticService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetUserStatisticByUserId(int id)
        {
            var result= _userStatisticService.GetUserStatisticByUserId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet]
        public IActionResult ShowUserStatistic(int id)
        {
            var result = _userStatisticService.ShowUserStatisticByUserId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]

        public IActionResult AddUserStatistics([FromBody] AddUserStatisticDto addUserStatisticDto)
        {
            var result = _userStatisticService.AddUserStatistics(_mapper.Map<UserStatisticDto>(addUserStatisticDto));
           if (result.Success) 
            {
                return Ok(result);   
            }  
           return BadRequest(result);
           
        }
    }
}
