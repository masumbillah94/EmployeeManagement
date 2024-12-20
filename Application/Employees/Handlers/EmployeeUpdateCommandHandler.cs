using Application.Common.BaseHandler;
using Application.Common.Models;
using Application.Employees.Employees.Commands;
using AutoMapper;
using Domain.Abstractions.Base;
using Domain.Dto.Employees;
using Domain.Entities.Employees;
using MediatR;

namespace Application.Employees.Employees.Handlers
{
    public class EmployeeUpdateCommandHandler : BaseHandler, IRequestHandler<EmployeeUpdateCommand, ResponseDetail<EmployeeReadDto>>
    {
        #region Public Constructors

        public EmployeeUpdateCommandHandler(IRepositoryFacade unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<ResponseDetail<EmployeeReadDto>> Handle(EmployeeUpdateCommand request, CancellationToken cancellationToken)
        {
            var response = ApplicationFactory.CreateResponseDetails<EmployeeReadDto>();
            try
            {
                var employee = _mapper.Map<Employee>(request);
                var result = await _repositoryFacade.EmployeeRepo.UpdateEntity(employee);
                if (result !=null)
                {
                    var employeeDto = _mapper.Map<EmployeeReadDto>(employee);
                    response.SuccessResponse(employeeDto, "Employee updated successfully");
                }
                else
                {
                    response.InvalidResponse("Employee Not Created");
                }
                return response;
            }
            catch (Exception ex)
            {
                return response.ErrorResponse(ex);
            }
        }

        #endregion Public Methods
    }
}
