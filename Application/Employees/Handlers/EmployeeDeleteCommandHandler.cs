using Application.Common.BaseHandler;
using Application.Common.Models;
using Application.Employees.Employees.Commands;
using AutoMapper;
using Domain.Abstractions.Base;
using Domain.Dto.Employees;
using MediatR;

namespace Application.Employees.Employees.Handlers
{
    public class EmployeeDeleteCommandHandler : BaseHandler, IRequestHandler<EmployeeDeleteCommand, ResponseDetail<EmployeeReadDto>>
    {
        #region Public Constructors

        public EmployeeDeleteCommandHandler(IRepositoryFacade unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<ResponseDetail<EmployeeReadDto>> Handle(EmployeeDeleteCommand request, CancellationToken cancellationToken)
        {
            var response = ApplicationFactory.CreateResponseDetails<EmployeeReadDto>();
            try
            {
                var employee = await _repositoryFacade.EmployeeRepo.GetByIdAsync(request.Id);
                if (employee == null)
                {
                    return response.InvalidResponse("Employee Not found");
                }
                var result = await _repositoryFacade.EmployeeRepo.DeleteByIdAsync(request.Id);
                if (result >0)
                {
                    var employeeDto = _mapper.Map<EmployeeReadDto>(employee);
                    response.SuccessResponse(employeeDto, "Employee deleted successfully.");
                }
                else
                {
                    response.InvalidResponse("Employee not deleted.");
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
