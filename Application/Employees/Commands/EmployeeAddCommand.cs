﻿using Application.Common.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;
using Domain.Dto.Employees;

namespace Application.Employees.Commands
{
    public class EmployeeAddCommand : IRequest<ResponseDetail<EmployeeReadDto>>
    {
        #region Public Properties

        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(50)]
        public string Email { get; set; } = string.Empty;
        [MaxLength(30)]
        public string Phone { get; set; } = string.Empty;
        [MaxLength(30)]
        public string Gender { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public string Status { get; set; } = string.Empty;
        [MaxLength(50)]
        public string Position { get; set; } = string.Empty;
        public DateTime? JoiningDate { get; set; }

        #endregion Public Properties
    }
}
