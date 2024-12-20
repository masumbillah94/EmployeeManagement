using Application.Common.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;
using Domain.Dto.PerformanceReviews;
using Domain.Dto.Departments;

namespace Application.PerformanceReviews.Commands
{
    public class PerformanceReviewAddCommand : IRequest<ResponseDetail<PerformanceReviewReadDto>>
    {
        #region Public Properties

        public long EmployeeId { get; set; }
        public int ReviewScore { get; set; }
        [MaxLength(200)]
        public string ReviewNote { get; set; } = string.Empty;

        #endregion Public Properties
    }
}
