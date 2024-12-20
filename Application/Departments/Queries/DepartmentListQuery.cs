using Application.Common.Models;
using Domain.Entities.Departments;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Dto.Departments;

namespace Application.Departments.Queries
{
    public class DepartmentListQuery : IRequest<ResponseDetail<List<PerformanceReviewsReadDto>>>
    {
    }
}
