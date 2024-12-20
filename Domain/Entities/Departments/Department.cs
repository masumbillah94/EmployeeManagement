using Domain.Entities.Base;
using Domain.Entities.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Departments
{
    public class Department : BaseEntity<int>
    {
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [ForeignKey("Manager")]
        public long? ManagerId { get; set; }
        public decimal Budget { get; set; }
        public virtual List<Employee> Employees { get; set; }
        public virtual Employee Manager { get; set; }
    }
}
