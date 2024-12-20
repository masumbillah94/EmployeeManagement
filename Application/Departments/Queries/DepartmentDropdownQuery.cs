using Application.Common.Models;
using Domain.Dto.Common;
using Domain.Dto.Employees;
using MediatR;

namespace Application.Departments.Queries
{
    public class DepartmentDropdownQuery : IRequest<ResponseDetail<List<DropDown>>>
    {

    }
}
