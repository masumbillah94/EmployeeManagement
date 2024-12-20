using Application.PerformanceReviews.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;

namespace WebAPI.Controllers.PerformanceReviews
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceReviewController : ControllerBase
    {

        private IMediator MediatorObject => HttpContext.RequestServices.GetService<IMediator>()!;

        public PerformanceReviewController()
        {

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PerformanceReviewAddCommand command)
        {
            var result = await MediatorObject.Send(command);
            return RequestResponse.ReturnResponse(result);
        }
    }
}
