using Domain.Entities.Base;
using Domain.Entities.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.EmployeePerformances
{
    public class PerformanceReview:BaseEntity<long>
    {
        [ForeignKey(nameof(Employee))]
        public long EmployeeId { get; set; }
        public DateOnly ReviewDate { get; set; }
        public int ReviewScore { get; set; }
        [MaxLength(200)]
        public string ReviewNote { get; set; } = string.Empty;
        public virtual Employee Employee { get; set; }
    }
}
