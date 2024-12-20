using Application.Common.Models;
using Domain.Dto.Employees;
using Domain.Entities.Departments;
using Domain.Entities.EmployeePerformances;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Application.Employees.Employees.Commands
{
    public class EmployeeUpdateCommand : IRequest<ResponseDetail<EmployeeReadDto>>
    {
        #region Public Properties

        public long Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(50)]
        public string Email { get; set; } = string.Empty;
        [MaxLength(30)]
        public string Phone { get; set; } = string.Empty;
        [MaxLength(30)]
        public string Gender { get; set; } = string.Empty;
        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }
        public string Status { get; set; } = string.Empty;
        [MaxLength(50)]
        public string Position { get; set; } = string.Empty;
        public DateTime? JoiningDate { get; set; }
        public virtual List<PerformanceReview> PerformanceReviews { get; set; }
    }

        #endregion Public Properties
    
}
