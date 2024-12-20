using AutoMapper;
using Domain.Dto.Departments;
using Domain.Dto.Employees;
using Domain.Entities.Departments;
using Domain.Entities.Employees;

namespace Application.Departments.Mappers
{
    public class DepartmentProfile : Profile
    {
        #region Public Constructors

        public DepartmentProfile()
        {
            CreateMap<Department, PerformanceReviewsReadDto>().ReverseMap();
        }

        #endregion Public Constructors
    }
}
