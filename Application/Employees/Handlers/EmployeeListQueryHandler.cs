using Application.Common.BaseHandler;
using Application.Common.Models;
using Application.Employees.Employees.Queries;
using AutoMapper;
using Domain.Abstractions.Base;
using Domain.Dto.Employees;
using Domain.Entities.Employees;
using MediatR;

namespace Application.Employees.Employees.Handlers
{
    public class EmployeeListQueryHandler : BaseHandler, IRequestHandler<EmployeeListQuery, ResponseDetail<List<EmployeeReadDto>>>
    {
        #region Public Constructors

        public EmployeeListQueryHandler(IRepositoryFacade unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<ResponseDetail<List<EmployeeReadDto>>> Handle(EmployeeListQuery request, CancellationToken cancellationToken)
        {
            var response = ApplicationFactory.CreateResponseDetails<List<EmployeeReadDto>>();
            try
            {
                var employeeList = await _repositoryFacade.EmployeeRepo.GetAllAsync(request.employeeName,request.departmentId,request.position,request.minPerformanceScore,request.maxPerformanceScore);
                //var employeeDtoList = employeeList.Select(d => new EmployeeReadDto()
                //{
                //    Id = d.Id,
                //    EmployeeName = d.EmployeeName,
                //    EmployeeCode = d.EmployeeCode,
                //    EmployeeAddress = d.EmployeeAddress,
                //    Degree = d.Degree,
                //    ContractNo = d.ContractNo,
                //    Designation = d.Designation,
                //    Email = d.Email,
                //    ClassID = d.ClassID,
                //    ClassName = d.EmployeeClass.ClassName,
                //    SpecialityID = d.SpecialityID,
                //    SpecialityName = d.EmployeeSpeciality.SpecialtyName
                //}).ToList();
                var employeeDtoList =  _mapper.Map<List<EmployeeReadDto>>(employeeList);
                response.SuccessResponse(employeeDtoList);
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
