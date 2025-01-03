﻿using Domain.Entities.Departments;
using Domain.Entities.EmployeePerformances;
using Domain.Entities.Employees;
using Microsoft.EntityFrameworkCore;

namespace Data.SqlServer.AppContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<PerformanceReview> PerformanceReviews { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
