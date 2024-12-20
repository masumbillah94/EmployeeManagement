using Application.Employees.Employees.Commands;
using Application.Employees.Employees.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UOS.API.Services;

namespace WebAPI.Controllers.Employees
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private IMediator MediatorObject =>  HttpContext.RequestServices.GetService<IMediator>()!;

        public EmployeeController()
        {
                
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeAddCommand command)
        {
            var result = await MediatorObject.Send(command);
            return RequestResponse.ReturnResponse(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EmployeeUpdateCommand command)
        {
            var result = await MediatorObject.Send(command);
            return RequestResponse.ReturnResponse(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] EmployeeDeleteCommand command)
        {
            var result = await MediatorObject.Send(command);
            return RequestResponse.ReturnResponse(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? employeeName, int? departmentId, string? position, int? minPerformanceScore, int? maxPerformanceScore, int pageNumber = 1, int pageSize = 10)
        {
            var result = await MediatorObject.Send(new EmployeeListQuery()
            {
                employeeName=employeeName,
                departmentId=departmentId,
                position=position,
                minPerformanceScore=minPerformanceScore,
                maxPerformanceScore=maxPerformanceScore,
                pageNumber=pageNumber,
                pageSize=pageSize
            });
            return RequestResponse.ReturnResponse(result);
        }

        [HttpGet("ById")]
        public async Task<IActionResult> Get([FromQuery] long id)
        {
            var result = await MediatorObject.Send(new EmployeeByIdQuery() { Id = id });
            return RequestResponse.ReturnResponse(result);
        }
    }
}
