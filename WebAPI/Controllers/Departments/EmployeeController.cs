using Application.Departments.Queries;
using Application.Employees.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;

namespace WebAPI.Controllers.Departments
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private IMediator MediatorObject => HttpContext.RequestServices.GetService<IMediator>()!;

        public DepartmentController()
        {

        }

        [HttpGet("Dropdown")]
        public async Task<IActionResult> Dropdown()
        {
            var result = await MediatorObject.Send(new DepartmentDropdownQuery());
            return RequestResponse.ReturnResponse(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await MediatorObject.Send(new DepartmentListQuery());
            return RequestResponse.ReturnResponse(result);
        }
    }
}
