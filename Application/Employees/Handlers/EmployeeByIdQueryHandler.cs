using Application.Common.BaseHandler;
using Application.Common.Models;
using Application.Employees.Employees.Queries;
using AutoMapper;
using Domain.Abstractions.Base;
using Domain.Dto.Employees;
using MediatR;

namespace Application.Employees.Employees.Handlers
{
    public class EmployeeByIdQueryHandler : BaseHandler, IRequestHandler<EmployeeByIdQuery, ResponseDetail<EmployeeReadDto>>
    {
        #region Public Constructors

        public EmployeeByIdQueryHandler(IRepositoryFacade unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<ResponseDetail<EmployeeReadDto>> Handle(EmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var response = ApplicationFactory.CreateResponseDetails<EmployeeReadDto>();
            try
            {
                var employee = await _repositoryFacade.EmployeeRepo.GetByIdAsync(request.Id);
                var employeeDto = _mapper.Map<EmployeeReadDto>(employee);
                //if (employee != null)
                //{
                //    employeeDto.Re = employee.ReviewScore;
                //    employeeDto.ClassName = employee.d;
                //}
                response.SuccessResponse(employeeDto);
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
