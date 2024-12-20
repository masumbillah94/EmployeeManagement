using Application.PerformanceReviews.Commands;
using AutoMapper;
using Domain.Dto.PerformanceReviews;
using Domain.Entities.EmployeePerformances;

namespace Application.PerformanceReviews.Mappers
{
    public class PerformanceReviewProfile : Profile
    {
        #region Public Constructors

        public PerformanceReviewProfile()
        {
            CreateMap<PerformanceReview, PerformanceReviewAddCommand>().ReverseMap();
            CreateMap<PerformanceReview, PerformanceReviewReadDto>().ReverseMap();
        }

        #endregion Public Constructors
    }
}
