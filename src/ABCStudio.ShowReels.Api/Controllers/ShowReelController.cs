using ABCStudio.ShowReels.Application.DTOs;
using ABCStudio.ShowReels.Application.Services;
using ABCStudio.ShowReels.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ABCStudio.ShowReels.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowReelController : ControllerBase
    {
        private readonly ShowReelService _showReelService;

        public ShowReelController(ShowReelService showReelService)
        {
            _showReelService = showReelService;
        }

        [HttpGet]
        public ObjectResult Get()
        {
            try
            {
                var response = _showReelService.GetShowReels();
                return new ObjectResult(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ObjectResult("Error occured.");
                errorResponse.StatusCode = 500;
                return errorResponse;
            }
        }

        [HttpPost]
        public ObjectResult Post(ShowReelDTO request)
        {
            try
            {
                var response = _showReelService.CreateShowReel(request);
                return new ObjectResult(response);
            }
            catch (ShowReelException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            catch (Exception ex)
            {
                var errorResponse = new ObjectResult("Error occured.");
                errorResponse.StatusCode = 500;
                return errorResponse;
            }
        }
    }
}
