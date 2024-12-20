using Domain.Entities.Departments;
using Domain.Entities.EmployeePerformances;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto.Employees
{
    public class EmployeeListDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public int? DepartmentId { get; set; }
        public string  DepartmentName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public int? ReviewScore { get; set; }
        public int? TotalRowCount { get; set; }
        public DateTime? JoiningDate { get; set; }
    }
}
