using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SpotifyClone.Business.abstracts;

namespace SpotifyClone.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AdminPanelController:ControllerBase
    {
        private readonly IAdminPanelService _adminPanelService;

        public AdminPanelController(IAdminPanelService adminPanelService)
        {
                _adminPanelService = adminPanelService;
        }

        [HttpGet]
        public IActionResult GetSystemStatistic()
        {
            var result = _adminPanelService.GetSystemStatiscs();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet]
        public IActionResult GetTotalIncome()
        {
            var result = _adminPanelService.GetTotalIncome();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet]
        public IActionResult CalculateProfitAndLoss()
        {
            var result = _adminPanelService.CalculateProfitAndLoss();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
