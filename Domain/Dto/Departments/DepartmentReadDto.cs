using Domain.Entities.Departments;
using Domain.Entities.EmployeePerformances;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto.Departments
{
    public class PerformanceReviewsReadDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Budget { get; set; }
    }
}
