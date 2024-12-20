using Application.Common.Models;
using Domain.Dto.Employees;
using Domain.Entities.Departments;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Application.Employees.Queries
{
    public class EmployeeListQuery : IRequest<ResponseDetail<List<EmployeeListDto>>>
    {
        public string? employeeName { get; set; }
        public int? departmentId { get; set; }
        public string? position { get; set; }
        public int? minPerformanceScore { get; set; }
        public int? maxPerformanceScore { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
    }
}
