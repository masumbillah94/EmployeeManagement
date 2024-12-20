using Application.Employees.Commands;
using AutoMapper;
using Domain.Dto.Employees;
using Domain.Entities.Employees;

namespace Application.Employees.Mappers
{
    public class EmployeeProfile : Profile
    {
        #region Public Constructors

        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeAddCommand>().ReverseMap();
            CreateMap<Employee, EmployeeReadDto>().ReverseMap();
            CreateMap<Employee, EmployeeDeleteCommand>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateCommand>().ReverseMap();
        }

        #endregion Public Constructors
    }
}
