using Application.Common.Models;
using Domain.Dto.Employees;
using MediatR;

namespace Application.Employees.Commands
{
    public class EmployeeDeleteCommand : IRequest<ResponseDetail<EmployeeReadDto>>
    {
        #region Public Properties

        public long Id { get; set; }

        #endregion Public Properties
    }
}
