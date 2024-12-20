using Domain.Entities.Base;
using Domain.Entities.Departments;
using Domain.Entities.EmployeePerformances;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Employees
{
    public class Employee : BaseEntity<long>
    {
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
}
